using System;

namespace TheToolsmiths.Ddl.Models.EntryTypes
{
    public class SubItemType : IEquatable<SubItemType>
    {
        private const StringComparison Comparison = StringComparison.OrdinalIgnoreCase;

        private readonly string subItemType;

        public SubItemType(ItemType itemType, string subItemType)
        {
            this.ItemType = itemType;
            this.subItemType = subItemType;
        }

        public ItemType ItemType { get; }

        public bool Equals(SubItemType? other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.ItemType.Equals(other.ItemType)
                   && string.Equals(this.subItemType, other.subItemType, Comparison);
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

            return this.Equals((SubItemType)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 31 + this.ItemType.GetHashCode();
                hash = hash * 31 + this.subItemType.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(SubItemType? left, SubItemType? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SubItemType? left, SubItemType? right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return string.Join('/', this.ItemType, this.subItemType);
        }
    }
}
