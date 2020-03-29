namespace TheToolsmiths.Ddl.Lexer
{
    public static class LexerTokenExtensions
    {
        public static bool IsIdentifier(this in LexerToken token)
        {
            return token.Kind == LexerTokenKind.Identifier;
        }

        public static bool IsListSeparator(this in LexerToken token)
        {
            return token.Kind == LexerTokenKind.ListSeparator;
        }

        public static bool IsOpenAttribute(this in LexerToken token)
        {
            return token.Kind == LexerTokenKind.OpenAttribute;
        }

        public static bool IsCloseAttribute(this in LexerToken token)
        {
            return token.Kind == LexerTokenKind.CloseAttribute;
        }

        public static bool IsOpenScope(this in LexerToken token)
        {
            return token.Kind == LexerTokenKind.OpenScope;
        }

        public static bool IsCloseScope(this in LexerToken token)
        {
            return token.Kind == LexerTokenKind.CloseScope;
        }

        public static bool IsOpenGenerics(this in LexerToken token)
        {
            return token.Kind == LexerTokenKind.OpenGenerics;
        }

        public static bool IsCloseGenerics(this in LexerToken token)
        {
            return token.Kind == LexerTokenKind.CloseGenerics;
        }

        public static bool IsOpenParentheses(this in LexerToken token)
        {
            return token.Kind == LexerTokenKind.OpenParentheses;
        }

        public static bool IsCloseParentheses(this in LexerToken token)
        {
            return token.Kind == LexerTokenKind.CloseParentheses;
        }

        public static bool IsNamespaceSeparator(this in LexerToken token)
        {
            return token.Kind == LexerTokenKind.NamespaceSeparator;
        }

        public static bool IsFieldInitialization(this in LexerToken token)
        {
            return token.Kind == LexerTokenKind.FieldInitialization;
        }

        public static bool IsLiteral(this in LexerToken token)
        {
            return token.Kind == LexerTokenKind.String
                   || token.Kind == LexerTokenKind.Number
                   || token.Kind == LexerTokenKind.Boolean;
        }
    }
}
