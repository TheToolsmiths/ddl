using System;

namespace TheToolsmiths.Ddl.Parser.Lexers
{
    public struct LexerToken
    {
        private LexerToken(LexerTokenKind kind, in Memory<char> memory)
        {
            this.Memory = memory;
            this.Kind = kind;
        }

        private LexerToken(LexerTokenKind kind)
        {
            this.Kind = kind;
            this.Memory = Memory<char>.Empty;
        }

        public Memory<char> Memory { get; }

        public LexerTokenKind Kind { get; }

        public static LexerToken CreateIdentifierToken(in Memory<char> memory)
        {
            return new LexerToken(LexerTokenKind.Identifier, memory);
        }

        public static LexerToken CreateOpenScopeToken()
        {
            return new LexerToken(LexerTokenKind.OpenScope);
        }

        public static LexerToken CreateCloseScopeToken()
        {
            return new LexerToken(LexerTokenKind.CloseScope);
        }

        public static LexerToken CreateValueAssignmentToken()
        {
            return new LexerToken(LexerTokenKind.ValueAssignment);
        }

        public static LexerToken CreateNamespaceSeparatorToken()
        {
            return new LexerToken(LexerTokenKind.NamespaceSeparator);
        }

        public static LexerToken CreateSlashToken()
        {
            return new LexerToken(LexerTokenKind.Slash);
        }

        public static LexerToken CreateListSeparatorToken()
        {
            return new LexerToken(LexerTokenKind.ListSeparator);
        }

        public static LexerToken CreateFieldInitializationToken()
        {
            return new LexerToken(LexerTokenKind.FieldInitialization);
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
                    return $"{nameof(LexerTokenKind.Identifier)} - '{token.Memory.ToString()}'";

                case LexerTokenKind.OpenScope:
                    return $"{nameof(LexerTokenKind.OpenScope)} - {CharConstants.OpenScope}";

                case LexerTokenKind.CloseScope:
                    return $"{nameof(LexerTokenKind.CloseScope)} - {CharConstants.CloseScope}";

                case LexerTokenKind.ValueAssignment:
                    return $"{nameof(LexerTokenKind.ValueAssignment)} - {CharConstants.Colon}";

                case LexerTokenKind.NamespaceSeparator:
                    return $"{nameof(LexerTokenKind.NamespaceSeparator)} - {CharConstants.Colon}{CharConstants.Colon}";

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
