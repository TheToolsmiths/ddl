using System.Threading.Tasks;

namespace TheToolsmiths.Ddl.Lexer
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

        public static ValueTask<TokenResult> TryGetOpenScopeToken(this DdlLexer lexer)
        {
            return TryGetTokenOfKind(lexer, LexerTokenKind.OpenScope);
        }

        public static ValueTask<TokenResult> TryGetCloseScopeToken(this DdlLexer lexer)
        {
            return TryGetTokenOfKind(lexer, LexerTokenKind.CloseScope);
        }

        public static ValueTask<TokenResult> TryGetOpenAttributeToken(this DdlLexer lexer)
        {
            return TryGetTokenOfKind(lexer, LexerTokenKind.OpenAttribute);
        }

        public static ValueTask<TokenResult> TryGetCloseAttributeToken(this DdlLexer lexer)
        {
            return TryGetTokenOfKind(lexer, LexerTokenKind.CloseAttribute);
        }

        public static ValueTask<TokenResult> TryPeekOpenAttributeToken(this DdlLexer lexer)
        {
            return TryPeekTokenOfKind(lexer, LexerTokenKind.OpenAttribute);
        }

        public static ValueTask<TokenResult> TryPeekCloseAttributeToken(this DdlLexer lexer)
        {
            return TryPeekTokenOfKind(lexer, LexerTokenKind.CloseAttribute);
        }

        public static ValueTask<TokenResult> TryPeekOpenScopeToken(this DdlLexer lexer)
        {
            return TryPeekTokenOfKind(lexer, LexerTokenKind.OpenScope);
        }

        public static ValueTask<TokenResult> TryPeekCloseScopeToken(this DdlLexer lexer)
        {
            return TryPeekTokenOfKind(lexer, LexerTokenKind.CloseScope);
        }

        public static ValueTask<TokenResult> TryGetValueAssignmentToken(this DdlLexer lexer)
        {
            return TryGetTokenOfKind(lexer, LexerTokenKind.ValueAssignment);
        }

        public static ValueTask<TokenResult> TryPeekValueAssignmentToken(this DdlLexer lexer)
        {
            return TryPeekTokenOfKind(lexer, LexerTokenKind.ValueAssignment);
        }

        public static ValueTask<TokenResult> TryPeekListSeparatorToken(this DdlLexer lexer)
        {
            return TryPeekTokenOfKind(lexer, LexerTokenKind.ListSeparator);
        }

        public static ValueTask<TokenResult> TryGetListSeparatorToken(this DdlLexer lexer)
        {
            return TryGetTokenOfKind(lexer, LexerTokenKind.ListSeparator);
        }

        public static async ValueTask<TokenResult> TryGetLiteralToken(this DdlLexer lexer)
        {
            var result = await lexer.TryGetNextToken();

            if (result.IsError)
            {
                return result;
            }

            if (result.Token.IsLiteral())
            {
                return result;
            }

            throw new System.NotImplementedException();
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
