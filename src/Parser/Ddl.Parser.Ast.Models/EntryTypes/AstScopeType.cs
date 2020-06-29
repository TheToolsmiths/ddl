using System;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.EntryTypes
{
    public class AstScopeType : IEquatable<AstScopeType>
    {
        private const StringComparison Comparison = StringComparison.OrdinalIgnoreCase;

        private readonly string type;

        public AstScopeType(string type)
        {
            this.type = type;
        }

        public bool Equals(AstScopeType? other)
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

            return this.Equals((AstScopeType)obj);
        }

        public override int GetHashCode()
        {
            return this.type.GetHashCode(Comparison);
        }

        public static bool operator ==(AstScopeType? left, AstScopeType? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AstScopeType? left, AstScopeType? right)
        {
            return !Equals(left, right);
        }
    }
}
