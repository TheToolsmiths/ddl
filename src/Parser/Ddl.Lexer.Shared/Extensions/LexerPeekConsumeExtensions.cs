using System.Threading.Tasks;

namespace TheToolsmiths.Ddl.Lexer
{
    public static class LexerPeekConsumeExtensions
    {
        public static ValueTask<bool> TryConsumeIdentifierToken(this ILexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.Identifier);
        }

        public static ValueTask<bool> TryConsumeOpenScopeToken(this ILexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.OpenScope);
        }

        public static ValueTask<bool> TryConsumeCloseScopeToken(this ILexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.CloseScope);
        }

        public static ValueTask<bool> TryConsumeOpenParenthesesToken(this ILexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.OpenParentheses);
        }

        public static ValueTask<bool> TryConsumeCloseParenthesesToken(this ILexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.CloseParentheses);
        }

        public static ValueTask<bool> TryConsumeOpenAttributeToken(this ILexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.OpenAttribute);
        }

        public static ValueTask<bool> TryConsumeCloseAttributeToken(this ILexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.CloseAttribute);
        }

        public static ValueTask<bool> TryConsumeOpenGenericsToken(this ILexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.OpenGenerics);
        }

        public static ValueTask<bool> TryConsumeCloseGenericsToken(this ILexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.CloseGenerics);
        }

        public static ValueTask<bool> TryConsumeAsteriskToken(this ILexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.Asterisk);
        }

        public static ValueTask<bool> TryConsumeValueAssignmentToken(this ILexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.ValueAssignment);
        }

        public static ValueTask<bool> TryConsumeLogicalNotToken(this ILexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.LogicalNot);
        }

        public static ValueTask<bool> TryConsumeLogicalOrToken(this ILexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.LogicalOr);
        }

        public static ValueTask<bool> TryConsumeLogicalAndToken(this ILexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.LogicalNot);
        }

        public static ValueTask<bool> TryConsumeFieldInitializationToken(this ILexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.FieldInitialization);
        }

        public static ValueTask<bool> TryConsumeListSeparatorToken(this ILexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.ListSeparator);
        }

        public static ValueTask<bool> TryConsumeNamespaceSeparatorToken(this ILexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.NamespaceSeparator);
        }

        public static ValueTask<bool> TryConsumeEndStatementToken(this ILexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.EndStatement);
        }

        private static async ValueTask<bool> TryConsumeTokenOfKind(ILexer lexer, LexerTokenKind tokenKind)
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
