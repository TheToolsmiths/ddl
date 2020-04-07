using System;

namespace TheToolsmiths.Ddl.Lexer
{
    public readonly struct LexerToken
    {
        private LexerToken(LexerTokenKind kind, in ReadOnlyMemory<char> memory)
        {
            this.Memory = memory;
            this.Kind = kind;
        }

        public ReadOnlyMemory<char> Memory { get; }

        public LexerTokenKind Kind { get; }

        public static LexerToken CreateIdentifierToken(in ReadOnlyMemory<char> memory)
        {
            return new LexerToken(LexerTokenKind.Identifier, memory);
        }

        public static LexerToken CreateNumberToken(in ReadOnlyMemory<char> memory)
        {
            return new LexerToken(LexerTokenKind.Number, memory);
        }

        public static LexerToken CreateStringToken(in ReadOnlyMemory<char> memory)
        {
            return new LexerToken(LexerTokenKind.String, memory);
        }

        public static LexerToken CreateOpenScopeToken()
        {
            return new LexerToken(LexerTokenKind.OpenScope, TokenMemoryConstants.OpenScope);
        }

        public static LexerToken CreateCloseScopeToken()
        {
            return new LexerToken(LexerTokenKind.CloseScope, TokenMemoryConstants.CloseScope);
        }

        public static LexerToken CreateOpenAttributeToken()
        {
            return new LexerToken(LexerTokenKind.OpenAttribute, TokenMemoryConstants.OpenAttribute);
        }

        public static LexerToken CreateCloseAttributeToken()
        {
            return new LexerToken(LexerTokenKind.CloseAttribute, TokenMemoryConstants.CloseAttribute);
        }

        public static LexerToken CreateOpenParenthesesToken()
        {
            return new LexerToken(LexerTokenKind.OpenParentheses, TokenMemoryConstants.OpenParentheses);
        }

        public static LexerToken CreateCloseParenthesesToken()
        {
            return new LexerToken(LexerTokenKind.CloseParentheses, TokenMemoryConstants.CloseParentheses);
        }

        public static LexerToken CreateOpenGenericsToken()
        {
            return new LexerToken(LexerTokenKind.OpenGenerics, TokenMemoryConstants.OpenGenerics);
        }

        public static LexerToken CreateCloseGenericsToken()
        {
            return new LexerToken(LexerTokenKind.CloseGenerics, TokenMemoryConstants.CloseGenerics);
        }

        public static LexerToken CreateValueAssignmentToken()
        {
            return new LexerToken(LexerTokenKind.ValueAssignment, TokenMemoryConstants.ValueAssignment);
        }

        public static LexerToken CreateNamespaceSeparatorToken()
        {
            return new LexerToken(LexerTokenKind.NamespaceSeparator, TokenMemoryConstants.NamespaceSeparator);
        }

        public static LexerToken CreateSlashToken()
        {
            return new LexerToken(LexerTokenKind.Slash, TokenMemoryConstants.Slash);
        }

        public static LexerToken CreateListSeparatorToken()
        {
            return new LexerToken(LexerTokenKind.ListSeparator, TokenMemoryConstants.ListSeparator);
        }

        public static LexerToken CreateEndStatementToken()
        {
            return new LexerToken(LexerTokenKind.EndStatement, TokenMemoryConstants.EndStatement);
        }

        public static LexerToken CreateFieldInitializationToken()
        {
            return new LexerToken(LexerTokenKind.FieldInitialization, TokenMemoryConstants.FieldInitialization);
        }

        public static LexerToken CreateEqualityToken()
        {
            return new LexerToken(LexerTokenKind.Equality, TokenMemoryConstants.Equality);
        }

        public static LexerToken CreateInequalityToken()
        {
            return new LexerToken(LexerTokenKind.Inequality, TokenMemoryConstants.Inequality);
        }

        public static LexerToken CreateLogicalAndToken()
        {
            return new LexerToken(LexerTokenKind.LogicalAnd, TokenMemoryConstants.LogicalAnd);
        }

        public static LexerToken CreateLogicalOrToken()
        {
            return new LexerToken(LexerTokenKind.LogicalOr, TokenMemoryConstants.LogicalOr);
        }

        public static LexerToken CreateLogicalNotToken()
        {
            return new LexerToken(LexerTokenKind.LogicalNot, TokenMemoryConstants.LogicalNot);
        }

        public static LexerToken CreateBinaryAndToken()
        {
            return new LexerToken(LexerTokenKind.BinaryAnd, TokenMemoryConstants.BinaryAnd);
        }

        public static LexerToken CreateBinaryOrToken()
        {
            return new LexerToken(LexerTokenKind.BinaryOr, TokenMemoryConstants.BinaryOr);
        }

        public static LexerToken CreateAsteriskToken()
        {
            return new LexerToken(LexerTokenKind.Asterisk, TokenMemoryConstants.Asterisk);
        }

        public static LexerToken CreateBooleanTrueToken()
        {
            return new LexerToken(LexerTokenKind.Boolean, TokenMemoryConstants.BooleanTrue);
        }

        public static LexerToken CreateBooleanFalseToken()
        {
            return new LexerToken(LexerTokenKind.Boolean, TokenMemoryConstants.BooleanFalse);
        }

        public override string ToString()
        {
            return LexerTokenHelper.AsString(this);
        }
    }

    public static class LexerTokenHelper
    {
        public static string AsString(in LexerToken token)
        {
            return token.Kind switch
            {
                LexerTokenKind.Identifier => $"{nameof(LexerTokenKind.Identifier)} - '{token.Memory}'",
                LexerTokenKind.OpenScope => $"{nameof(LexerTokenKind.OpenScope)} - {TokenMemoryConstants.OpenScope}",
                LexerTokenKind.CloseScope => $"{nameof(LexerTokenKind.CloseScope)} - {TokenMemoryConstants.CloseScope}",
                LexerTokenKind.ValueAssignment => $"{nameof(LexerTokenKind.ValueAssignment)} - {TokenMemoryConstants.ValueAssignment}",
                LexerTokenKind.NamespaceSeparator => $"{nameof(LexerTokenKind.NamespaceSeparator)} - {TokenMemoryConstants.NamespaceSeparator}",
                LexerTokenKind.ListSeparator => $"{nameof(LexerTokenKind.ListSeparator)} - {TokenMemoryConstants.ListSeparator}",
                LexerTokenKind.OpenAttribute => $"{nameof(LexerTokenKind.OpenAttribute)} - {TokenMemoryConstants.OpenAttribute}",
                LexerTokenKind.CloseAttribute => $"{nameof(LexerTokenKind.CloseAttribute)} - {TokenMemoryConstants.CloseAttribute}",
                LexerTokenKind.FieldInitialization => $"{nameof(LexerTokenKind.FieldInitialization)} - {TokenMemoryConstants.FieldInitialization}",
                LexerTokenKind.String => $"{nameof(LexerTokenKind.String)} - '{token.Memory}'",
                LexerTokenKind.Boolean => $"{nameof(LexerTokenKind.Boolean)} - '{token.Memory}'",
                LexerTokenKind.Number => $"{nameof(LexerTokenKind.Number)} - '{token.Memory}'",
                LexerTokenKind.EndStatement => $"{nameof(LexerTokenKind.EndStatement)} - '{TokenMemoryConstants.EndStatement}'",
                LexerTokenKind.Slash => $"{nameof(LexerTokenKind.Slash)} - '{TokenMemoryConstants.Slash}'",
                LexerTokenKind.OpenParentheses => $"{nameof(LexerTokenKind.OpenParentheses)} - '{TokenMemoryConstants.OpenParentheses}'",
                LexerTokenKind.CloseParentheses => $"{nameof(LexerTokenKind.CloseParentheses)} - '{TokenMemoryConstants.CloseParentheses}'",
                LexerTokenKind.LogicalAnd => $"{nameof(LexerTokenKind.LogicalAnd)} - '{TokenMemoryConstants.LogicalAnd}'",
                LexerTokenKind.LogicalOr => $"{nameof(LexerTokenKind.LogicalOr)} - '{TokenMemoryConstants.LogicalOr}'",
                LexerTokenKind.BinaryAnd => $"{nameof(LexerTokenKind.BinaryAnd)} - '{TokenMemoryConstants.BinaryAnd}'",
                LexerTokenKind.BinaryOr => $"{nameof(LexerTokenKind.BinaryOr)} - '{TokenMemoryConstants.BinaryOr}'",
                LexerTokenKind.LogicalNot => $"{nameof(LexerTokenKind.LogicalNot)} - '{TokenMemoryConstants.LogicalNot}'",
                LexerTokenKind.OpenGenerics => $"{nameof(LexerTokenKind.OpenGenerics)} - '{TokenMemoryConstants.OpenGenerics}'",
                LexerTokenKind.CloseGenerics => $"{nameof(LexerTokenKind.CloseGenerics)} - '{TokenMemoryConstants.CloseGenerics}'",
                LexerTokenKind.Equality => $"{nameof(LexerTokenKind.Equality)} - '{TokenMemoryConstants.Equality}'",
                LexerTokenKind.Inequality => $"{nameof(LexerTokenKind.Inequality)} - '{TokenMemoryConstants.Inequality}'",
                LexerTokenKind.Asterisk => $"{nameof(LexerTokenKind.Asterisk)} - '{TokenMemoryConstants.Asterisk}'",
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
