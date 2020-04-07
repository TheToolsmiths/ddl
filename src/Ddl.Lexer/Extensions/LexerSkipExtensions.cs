using System.Threading.Tasks;

namespace TheToolsmiths.Ddl.Lexer
{
    public static class LexerSkipExtensions
    {
        public static ValueTask<bool> TrySkipIdentifierToken(this DdlLexer lexer)
        {
            return TrySkipTokenOfKind(lexer, LexerTokenKind.Identifier);
        }

        public static ValueTask<bool> TrySkipOpenScopeToken(this DdlLexer lexer)
        {
            return TrySkipTokenOfKind(lexer, LexerTokenKind.OpenScope);
        }

        public static ValueTask<bool> TrySkipCloseScopeToken(this DdlLexer lexer)
        {
            return TrySkipTokenOfKind(lexer, LexerTokenKind.CloseScope);
        }

        public static ValueTask<bool> TrySkipOpenAttributeToken(this DdlLexer lexer)
        {
            return TrySkipTokenOfKind(lexer, LexerTokenKind.OpenAttribute);
        }

        public static ValueTask<bool> TrySkipCloseAttributeToken(this DdlLexer lexer)
        {
            return TrySkipTokenOfKind(lexer, LexerTokenKind.CloseAttribute);
        }

        public static ValueTask<bool> TrySkipValueAssignmentToken(this DdlLexer lexer)
        {
            return TrySkipTokenOfKind(lexer, LexerTokenKind.ValueAssignment);
        }

        public static ValueTask<bool> TrySkipFieldInitializationToken(this DdlLexer lexer)
        {
            return TrySkipTokenOfKind(lexer, LexerTokenKind.FieldInitialization);
        }

        public static ValueTask<bool> TrySkipListSeparatorToken(this DdlLexer lexer)
        {
            return TrySkipTokenOfKind(lexer, LexerTokenKind.ListSeparator);
        }

        public static ValueTask<bool> TrySkipEndStatement(this DdlLexer lexer)
        {
            return TrySkipTokenOfKind(lexer, LexerTokenKind.EndStatement);
        }

        private static async ValueTask<bool> TrySkipTokenOfKind(DdlLexer lexer, LexerTokenKind tokenKind)
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
