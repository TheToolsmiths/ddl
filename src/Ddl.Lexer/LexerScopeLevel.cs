using System;

namespace TheToolsmiths.Ddl.Lexer
{
    public readonly struct LexerScopeLevel : IEquatable<LexerScopeLevel>
    {
        private LexerScopeLevel(int level)
        {
            if (level < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(level));
            }

            this.Level = level;
        }

        public int Level { get; }

        public LexerScopeLevel Increase()
        {
            return new LexerScopeLevel(this.Level + 1);
        }

        public LexerScopeLevel Decrease()
        {
            return new LexerScopeLevel(this.Level - 1);
        }

        public bool Equals(LexerScopeLevel other)
        {
            return this.Level == other.Level;
        }

        public override bool Equals(object? obj)
        {
            return obj is LexerScopeLevel other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return this.Level;
        }

        public static bool operator ==(LexerScopeLevel left, LexerScopeLevel right)
        {
            return left.Level == right.Level;
        }

        public static bool operator !=(LexerScopeLevel left, LexerScopeLevel right)
        {
            return left.Level != right.Level;
        }


    }
}
