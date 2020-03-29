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

        public override string ToString()
        {
            return LexerTokenHelper.AsString(this);
        }
    }

    public static class LexerTokenHelper
    {
        public static string AsString(in LexerToken token)
        {
            switch (token.Kind)
            {
                case LexerTokenKind.Identifier:
                    return $"{nameof(LexerTokenKind.Identifier)} - '{token.Memory}'";

                case LexerTokenKind.OpenScope:
                    return $"{nameof(LexerTokenKind.OpenScope)} - {TokenMemoryConstants.OpenScope}";

                case LexerTokenKind.CloseScope:
                    return $"{nameof(LexerTokenKind.CloseScope)} - {TokenMemoryConstants.CloseScope}";

                case LexerTokenKind.ValueAssignment:
                    return $"{nameof(LexerTokenKind.ValueAssignment)} - {TokenMemoryConstants.ValueAssignment}";

                case LexerTokenKind.NamespaceSeparator:
                    return $"{nameof(LexerTokenKind.NamespaceSeparator)} - {TokenMemoryConstants.NamespaceSeparator}";

                case LexerTokenKind.ListSeparator:
                    return $"{nameof(LexerTokenKind.ListSeparator)} - {TokenMemoryConstants.ListSeparator}";

                case LexerTokenKind.OpenAttribute:
                    return $"{nameof(LexerTokenKind.OpenAttribute)} - {TokenMemoryConstants.OpenAttribute}";

                case LexerTokenKind.CloseAttribute:
                    return $"{nameof(LexerTokenKind.CloseAttribute)} - {TokenMemoryConstants.CloseAttribute}";

                case LexerTokenKind.FieldInitialization:
                    return $"{nameof(LexerTokenKind.FieldInitialization)} - {TokenMemoryConstants.FieldInitialization}";

                case LexerTokenKind.String:
                    return $"{nameof(LexerTokenKind.String)} - '{token.Memory}'";
                case LexerTokenKind.Boolean:
                    return $"{nameof(LexerTokenKind.Boolean)} - '{token.Memory}'";
                case LexerTokenKind.Number:
                    return $"{nameof(LexerTokenKind.Number)} - '{token.Memory}'";

                //case LexerTokenKind.:
                //    return $"{nameof(LexerTokenKind.)} - {TokenMemoryConstants.}";

                //case LexerTokenKind.:
                //    return $"{nameof(LexerTokenKind.)} - {TokenMemoryConstants.}";

                //case LexerTokenKind.:
                //    return $"{nameof(LexerTokenKind.)} - {TokenMemoryConstants.}";

                //case LexerTokenKind.:
                //    return $"{nameof(LexerTokenKind.)} - {TokenMemoryConstants.}";

                //case LexerTokenKind.:
                //    return $"{nameof(LexerTokenKind.)} - {TokenMemoryConstants.}";

                //case LexerTokenKind.:
                //    return $"{nameof(LexerTokenKind.)} - {TokenMemoryConstants.}";

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
