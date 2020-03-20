using System;

namespace TheToolsmiths.Ddl.Parser.Lexers
{
    internal ref struct LexerCharEnumerator
    {
        private readonly ReadOnlySpan<char> chars;

        public LexerCharEnumerator(in ReadOnlySpan<char> chars)
        {
            this.chars = chars;
            this.CurrentIndex = 0;
            this.Current = default;
            this.Current = this.HasCurrent ? chars[0] : default;
        }

        public char Current { get; private set; }

        public int CurrentIndex { get; private set; }

        public bool HasCurrent => this.CurrentIndex < this.chars.Length;

        public bool HasNext => this.CurrentIndex + 1 < this.chars.Length;

        public bool MoveNext()
        {
            this.CurrentIndex++;

            this.Current = this.HasCurrent ? this.chars[this.CurrentIndex] : default;

            return this.HasCurrent;
        }

        public bool TryPeek(out char c)
        {
            if (this.CurrentIndex + 1 < this.chars.Length)
            {
                c = this.chars[this.CurrentIndex + 1];
                return true;
            }

            c = default;
            return false;
        }

        public ReadOnlySpan<char> GetRange(in Range range)
        {
            return this.chars[range];
        }
    }
}
