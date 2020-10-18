using System;

namespace TheToolsmiths.Ddl.Models.Compiled.ContentUnits
{
    public readonly struct ContentUnitId : IEquatable<ContentUnitId>
    {
        private static int nextId;

        private readonly int value;

        private ContentUnitId(int value)
        {
            this.value = value;
        }

        public static ContentUnitId CreateNew() => new ContentUnitId(nextId++);

        public bool Equals(ContentUnitId other)
        {
            return this.value == other.value;
        }

        public override bool Equals(object? obj)
        {
            return obj is ContentUnitId other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return this.value;
        }

        public static bool operator ==(ContentUnitId left, ContentUnitId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ContentUnitId left, ContentUnitId right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return $"ContentUnit '{this.value}'";
        }
    }
}
