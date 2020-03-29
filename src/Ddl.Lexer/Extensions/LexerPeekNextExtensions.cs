using System.Threading.Tasks;

namespace TheToolsmiths.Ddl.Lexer
{
    public static class LexerPeekNextExtensions
    {
        public static ValueTask<bool> IsNextIdentifierToken(this DdlLexer lexer)
        {
            return IsNextTokenOfKind(lexer, LexerTokenKind.Identifier);
        }

        public static ValueTask<bool> IsNextOpenScopeToken(this DdlLexer lexer)
        {
            return IsNextTokenOfKind(lexer, LexerTokenKind.OpenScope);
        }

        public static ValueTask<bool> IsNextCloseScopeToken(this DdlLexer lexer)
        {
            return IsNextTokenOfKind(lexer, LexerTokenKind.CloseScope);
        }

        public static ValueTask<bool> IsNextOpenAttributeToken(this DdlLexer lexer)
        {
            return IsNextTokenOfKind(lexer, LexerTokenKind.OpenAttribute);
        }

        public static ValueTask<bool> IsNextCloseAttributeToken(this DdlLexer lexer)
        {
            return IsNextTokenOfKind(lexer, LexerTokenKind.CloseAttribute);
        }

        public static ValueTask<bool> IsNextValueAssignmentToken(this DdlLexer lexer)
        {
            return IsNextTokenOfKind(lexer, LexerTokenKind.ValueAssignment);
        }

        public static ValueTask<bool> IsNextListSeparatorToken(this DdlLexer lexer)
        {
            return IsNextTokenOfKind(lexer, LexerTokenKind.ListSeparator);
        }

        public static async ValueTask<bool> IsNextTokenOfKind(DdlLexer lexer, LexerTokenKind tokenKind)
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
