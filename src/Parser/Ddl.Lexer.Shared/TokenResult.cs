using System;

namespace TheToolsmiths.Ddl.Lexer
{
    public readonly struct TokenResult
    {
        private readonly LexerToken? token;

        private TokenResult(LexerToken token)
        {
            this.token = token;
        }

        private TokenResult(bool result)
        {
            if (result)
            {
                throw new ArgumentException(nameof(result));
            }

            this.token = default;
        }

        public bool HasToken => this.token.HasValue;

        public LexerToken Token => this.token!.Value;

        public bool IsError => this.HasToken == false;

        public static TokenResult CreateResult(LexerToken token)
        {
            return new TokenResult(token);
        }

        public static TokenResult CreateNotFound()
        {
            return new TokenResult(false);
        }
    }
}
