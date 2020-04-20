using System.Threading.Tasks;

namespace TheToolsmiths.Ddl.Lexer
{
    public static class LexerSkipExtensions
    {
        public static ValueTask<bool> TrySkipIdentifierToken(this ILexer lexer)
        {
            return TrySkipTokenOfKind(lexer, LexerTokenKind.Identifier);
        }

        public static ValueTask<bool> TrySkipOpenScopeToken(this ILexer lexer)
        {
            return TrySkipTokenOfKind(lexer, LexerTokenKind.OpenScope);
        }

        public static ValueTask<bool> TrySkipCloseScopeToken(this ILexer lexer)
        {
            return TrySkipTokenOfKind(lexer, LexerTokenKind.CloseScope);
        }

        public static ValueTask<bool> TrySkipOpenAttributeToken(this ILexer lexer)
        {
            return TrySkipTokenOfKind(lexer, LexerTokenKind.OpenAttribute);
        }

        public static ValueTask<bool> TrySkipCloseAttributeToken(this ILexer lexer)
        {
            return TrySkipTokenOfKind(lexer, LexerTokenKind.CloseAttribute);
        }

        public static ValueTask<bool> TrySkipValueAssignmentToken(this ILexer lexer)
        {
            return TrySkipTokenOfKind(lexer, LexerTokenKind.ValueAssignment);
        }

        public static ValueTask<bool> TrySkipFieldInitializationToken(this ILexer lexer)
        {
            return TrySkipTokenOfKind(lexer, LexerTokenKind.FieldInitialization);
        }

        public static ValueTask<bool> TrySkipListSeparatorToken(this ILexer lexer)
        {
            return TrySkipTokenOfKind(lexer, LexerTokenKind.ListSeparator);
        }

        public static ValueTask<bool> TrySkipEndStatement(this ILexer lexer)
        {
            return TrySkipTokenOfKind(lexer, LexerTokenKind.EndStatement);
        }

        private static async ValueTask<bool> TrySkipTokenOfKind(ILexer lexer, LexerTokenKind tokenKind)
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
