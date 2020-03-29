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

        public static ValueTask<bool> TryConsumeOpenAttributeToken(this DdlLexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.OpenAttribute);
        }

        public static ValueTask<bool> TryConsumeCloseAttributeToken(this DdlLexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.CloseAttribute);
        }

        public static ValueTask<bool> TryConsumeValueAssignmentToken(this DdlLexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.ValueAssignment);
        }

        public static ValueTask<bool> TryConsumeFieldInitializationToken(this DdlLexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.FieldInitialization);
        }

        public static ValueTask<bool> TryConsumeListSeparatorToken(this DdlLexer lexer)
        {
            return TryConsumeTokenOfKind(lexer, LexerTokenKind.ListSeparator);
        }

        private static async ValueTask<bool> TryConsumeTokenOfKind(DdlLexer lexer, LexerTokenKind tokenKind)
        {
            var result = await lexer.TryGetNextToken();

            if (result.IsError)
            {
                return false;
            }

            return result.Token.Kind == tokenKind;
        }
    }
}
