using System;

namespace TheToolsmiths.Ddl.Lexer
{
    public readonly struct DoubleTokenResult
    {
        private DoubleTokenResult(LexerToken firstToken, LexerToken secondToken)
        {
            this.HasToken = true;
            this.FirstToken = firstToken;
            this.SecondToken = secondToken;
        }

        private DoubleTokenResult(bool result)
        {
            if (result)
            {
                throw new ArgumentException(nameof(result));
            }

            this.HasToken = false;
            this.FirstToken = default!;
            this.SecondToken = default!;
        }

        public bool HasToken { get; }

        public LexerToken FirstToken { get; }

        public LexerToken SecondToken { get; }

        public bool IsError => this.HasToken == false;

        public static DoubleTokenResult CreateResult(LexerToken first, LexerToken second)
        {
            return new DoubleTokenResult(first, second);
        }

        public static DoubleTokenResult CreateNotFound()
        {
            return new DoubleTokenResult(false);
        }
    }
}
