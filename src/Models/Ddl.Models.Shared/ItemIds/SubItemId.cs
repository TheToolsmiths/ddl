using System;

namespace TheToolsmiths.Ddl.Models.ItemIds
{
    public readonly struct SubItemId : IEquatable<SubItemId>
    {
        private static int nextId;

        private readonly int value;

        private SubItemId(int value)
        {
            this.value = value;
        }

        public static SubItemId CreateNew() => new SubItemId(nextId++);

        public bool Equals(SubItemId other)
        {
            return this.value == other.value;
        }

        public override bool Equals(object? obj)
        {
            return obj is SubItemId other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return this.value;
        }

        public static bool operator ==(SubItemId left, SubItemId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SubItemId left, SubItemId right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return $"Item Id '{this.value}'";
        }

        public int ToInt() => this.value;
    }
}
