using System;

namespace TheToolsmiths.Ddl.Models.ContentUnits
{
    public readonly struct ContentUnitItemId : IEquatable<ContentUnitItemId>
    {
        private static int nextId;

        private readonly int value;

        private ContentUnitItemId(int value)
        {
            this.value = value;
        }

        public static ContentUnitItemId CreateNew() => new ContentUnitItemId(nextId++);

        public bool Equals(ContentUnitItemId other)
        {
            return this.value == other.value;
        }

        public override bool Equals(object obj)
        {
            return obj is ContentUnitItemId other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return this.value;
        }

        public static bool operator ==(ContentUnitItemId left, ContentUnitItemId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ContentUnitItemId left, ContentUnitItemId right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return $"Item Id '{this.value}'";
        }
    }
}
