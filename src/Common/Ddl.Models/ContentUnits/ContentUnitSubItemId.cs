using System;

namespace TheToolsmiths.Ddl.Models.ContentUnits
{
    public readonly struct ContentUnitSubItemId : IEquatable<ContentUnitSubItemId>
    {
        private static int nextId;

        private readonly int value;

        private ContentUnitSubItemId(int value)
        {
            this.value = value;
        }

        public static ContentUnitSubItemId CreateNew() => new ContentUnitSubItemId(nextId++);

        public bool Equals(ContentUnitSubItemId other)
        {
            return this.value == other.value;
        }

        public override bool Equals(object obj)
        {
            return obj is ContentUnitSubItemId other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return this.value;
        }

        public static bool operator ==(ContentUnitSubItemId left, ContentUnitSubItemId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ContentUnitSubItemId left, ContentUnitSubItemId right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return $"Item Id '{this.value}'";
        }
    }
}
