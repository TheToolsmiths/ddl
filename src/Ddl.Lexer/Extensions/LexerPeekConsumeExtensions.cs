using System.Threading.Tasks;

namespace TheToolsmiths.Ddl.Lexer
{
    public static class LexerPeekConsumeExtensions
    {
        public static ValueTask<bool> TryConsumeIdentifierToken(this DdlLexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.Identifier);
        }

        public static ValueTask<bool> TryConsumeOpenScopeToken(this DdlLexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.OpenScope);
        }

        public static ValueTask<bool> TryConsumeCloseScopeToken(this DdlLexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.CloseScope);
        }

        public static ValueTask<bool> TryConsumeOpenParenthesesToken(this DdlLexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.OpenParentheses);
        }

        public static ValueTask<bool> TryConsumeCloseParenthesesToken(this DdlLexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.CloseParentheses);
        }

        public static ValueTask<bool> TryConsumeOpenAttributeToken(this DdlLexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.OpenAttribute);
        }

        public static ValueTask<bool> TryConsumeCloseAttributeToken(this DdlLexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.CloseAttribute);
        }

        public static ValueTask<bool> TryConsumeOpenGenericsToken(this DdlLexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.OpenGenerics);
        }

        public static ValueTask<bool> TryConsumeCloseGenericsToken(this DdlLexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.CloseGenerics);
        }

        public static ValueTask<bool> TryConsumeValueAssignmentToken(this DdlLexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.ValueAssignment);
        }

        public static ValueTask<bool> TryConsumeLogicalNotToken(this DdlLexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.LogicalNot);
        }

        public static ValueTask<bool> TryConsumeLogicalOrToken(this DdlLexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.LogicalOr);
        }

        public static ValueTask<bool> TryConsumeLogicalAndToken(this DdlLexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.LogicalNot);
        }

        public static ValueTask<bool> TryConsumeFieldInitializationToken(this DdlLexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.FieldInitialization);
        }

        public static ValueTask<bool> TryConsumeListSeparatorToken(this DdlLexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.ListSeparator);
        }

        public static ValueTask<bool> TryConsumeNamespaceSeparatorToken(this DdlLexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.NamespaceSeparator);
        }

        private static async ValueTask<bool> TryConsumeTokenOfKind(DdlLexer lexer, LexerTokenKind tokenKind)
        {
            var result = await lexer.TryPeekToken();

            if (result.IsError)
            {
                return false;
            }

            if (result.Token.Kind != tokenKind)
            {
                return false;
            }

            lexer.PopToken();
            return true;

        }
    }
}
