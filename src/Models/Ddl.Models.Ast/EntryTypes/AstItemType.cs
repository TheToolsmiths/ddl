using System;

namespace TheToolsmiths.Ddl.Models.Ast.EntryTypes
{
    public class AstItemType : IEquatable<AstItemType>
    {
        private const StringComparison Comparison = StringComparison.OrdinalIgnoreCase;

        private readonly string type;

        public AstItemType(string type)
        {
            this.type = type;
        }

        public bool Equals(AstItemType? other)
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

            return this.Equals((AstItemType)obj);
        }

        public override int GetHashCode()
        {
            return this.type.GetHashCode(Comparison);
        }

        public static bool operator ==(AstItemType? left, AstItemType? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AstItemType? left, AstItemType? right)
        {
            return !Equals(left, right);
        }
    }
}
