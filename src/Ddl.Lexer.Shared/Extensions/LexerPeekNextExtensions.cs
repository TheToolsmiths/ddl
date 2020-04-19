using System.Threading.Tasks;

namespace TheToolsmiths.Ddl.Lexer
{
    public static class LexerPeekNextExtensions
    {
        public static ValueTask<bool> IsNextIdentifierToken(this ILexer lexer)
        {
            return IsNextTokenOfKind(lexer, LexerTokenKind.Identifier);
        }

        public static ValueTask<bool> IsNextOpenScopeToken(this ILexer lexer)
        {
            return IsNextTokenOfKind(lexer, LexerTokenKind.OpenScope);
        }

        public static ValueTask<bool> IsNextCloseScopeToken(this ILexer lexer)
        {
            return IsNextTokenOfKind(lexer, LexerTokenKind.CloseScope);
        }

        public static ValueTask<bool> IsNextOpenAttributeToken(this ILexer lexer)
        {
            return IsNextTokenOfKind(lexer, LexerTokenKind.OpenAttribute);
        }

        public static ValueTask<bool> IsNextCloseAttributeToken(this ILexer lexer)
        {
            return IsNextTokenOfKind(lexer, LexerTokenKind.CloseAttribute);
        }

        public static ValueTask<bool> IsNextOpenParenthesesToken(this ILexer lexer)
        {
            return IsNextTokenOfKind(lexer, LexerTokenKind.OpenParentheses);
        }

        public static ValueTask<bool> IsNextCloseParenthesesToken(this ILexer lexer)
        {
            return IsNextTokenOfKind(lexer, LexerTokenKind.CloseParentheses);
        }

        public static ValueTask<bool> IsNextValueAssignmentToken(this ILexer lexer)
        {
            return IsNextTokenOfKind(lexer, LexerTokenKind.ValueAssignment);
        }

        public static ValueTask<bool> IsNextListSeparatorToken(this ILexer lexer)
        {
            return IsNextTokenOfKind(lexer, LexerTokenKind.ListSeparator);
        }

        public static async ValueTask<bool> IsNextTokenOfKind(ILexer lexer, LexerTokenKind tokenKind)
        {
            var result = await lexer.TryPeekToken();

            if (result.IsError)
            {
                return false;
            }

            return result.Token.Kind == tokenKind;
        }
    }
}
