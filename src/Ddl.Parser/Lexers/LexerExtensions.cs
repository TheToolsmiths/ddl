using System.Threading.Tasks;

namespace TheToolsmiths.Ddl.Parser.Lexers
{
    public static class LexerExtensions
    {
        public static ValueTask<TokenResult> TryGetIdentifierToken(this DdlLexer lexer)
        {
            return TryGetTokenOfKind(lexer, LexerTokenKind.Identifier);
        }

        public static ValueTask<TokenResult> TryPeekIdentifierToken(this DdlLexer lexer)
        {
            return TryPeekTokenOfKind(lexer, LexerTokenKind.Identifier);
        }

        public static ValueTask<TokenResult> TryGetValueAssignmentToken(this DdlLexer lexer)
        {
            return TryGetTokenOfKind(lexer, LexerTokenKind.ValueAssignment);
        }

        public static ValueTask<TokenResult> TryPeekValueAssignmentToken(this DdlLexer lexer)
        {
            return TryPeekTokenOfKind(lexer, LexerTokenKind.ValueAssignment);
        }

        public static async ValueTask<TokenResult> TryGetTokenOfKind(DdlLexer lexer, LexerTokenKind tokenKind)
        {
            var result = await lexer.TryGetNextToken();

            if (result.IsError)
            {
                return result;
            }

            if (result.Token.Kind == tokenKind)
            {
                return result;
            }

            throw new System.NotImplementedException();
        }

        public static async ValueTask<TokenResult> TryPeekTokenOfKind(DdlLexer lexer, LexerTokenKind tokenKind)
        {
            var result = await lexer.TryPeekToken();

            if (result.IsError)
            {
                return result;
            }

            if (result.Token.Kind == tokenKind)
            {
                return result;
            }

            throw new System.NotImplementedException();
        }
    }
}
