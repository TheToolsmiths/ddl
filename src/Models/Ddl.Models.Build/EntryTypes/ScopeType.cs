using System;

namespace TheToolsmiths.Ddl.Models.Build.EntryTypes
{
    public class ScopeType : IEquatable<ScopeType>
    {
        private const StringComparison Comparison = StringComparison.OrdinalIgnoreCase;

        private readonly string type;

        public ScopeType(string type)
        {
            this.type = type;
        }

        public bool Equals(ScopeType? other)
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

            return this.Equals((ScopeType)obj);
        }

        public override int GetHashCode()
        {
            return this.type.GetHashCode(Comparison);
        }

        public static bool operator ==(ScopeType? left, ScopeType? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ScopeType? left, ScopeType? right)
        {
            return !Equals(left, right);
        }
    }
}
