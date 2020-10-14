using System;

namespace TheToolsmiths.Ddl.Models.Build.EntryTypes
{
    public class ItemType : IEquatable<ItemType>
    {
        private const StringComparison Comparison = StringComparison.OrdinalIgnoreCase;

        private readonly string type;

        public ItemType(string type)
        {
            this.type = type;
        }

        public bool Equals(ItemType? other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(this.type, other.type, Comparison);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((ItemType)obj);
        }

        public override int GetHashCode()
        {
            return this.type.GetHashCode(Comparison);
        }

        public static bool operator ==(ItemType? left, ItemType? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ItemType? left, ItemType? right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return this.type;
        }
    }
}
