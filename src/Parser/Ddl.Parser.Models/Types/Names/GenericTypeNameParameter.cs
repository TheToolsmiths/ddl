using System;

namespace TheToolsmiths.Ddl.Parser.Models.Types.Names
{
    public class GenericTypeNameParameter : IEquatable<GenericTypeNameParameter>
    {
        public GenericTypeNameParameter(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("Identifier text is required", nameof(text));
            }

            this.Text = text;
        }

        public string Text { get; }

        public override string ToString()
        {
            return this.Text;
        }

        public static bool Equals(GenericTypeNameParameter a, GenericTypeNameParameter b)
        {
            if (a is null)
            {
                return false;
            }

            if (b is null)
            {
                return false;
            }

            return ReferenceEquals(a, b) || string.Equals(a.Text, b.Text, StringComparison.InvariantCulture);
        }

        public bool Equals(GenericTypeNameParameter? other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(this.Text, other.Text, StringComparison.InvariantCulture);
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

            return this.Equals((GenericTypeNameParameter)obj);
        }

        public override int GetHashCode()
        {
            return this.Text != null ? this.Text.GetHashCode(StringComparison.InvariantCulture) : 0;
        }

        public static bool operator ==(GenericTypeNameParameter left, GenericTypeNameParameter right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(GenericTypeNameParameter left, GenericTypeNameParameter right)
        {
            return Equals(left, right) == false;
        }
    }
}
