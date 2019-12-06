using System;

namespace TheToolsmiths.Ddl.Models.Identifiers
{
    public class Identifier : IEquatable<Identifier>
    {
        public Identifier(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException(nameof(text));
            }

            this.Text = text;
        }

        public string Text { get; }

        public override string ToString()
        {
            return this.Text;
        }

        public static Identifier FromString(string text)
        {
            return new Identifier(text);
        }

        public static bool Equals(Identifier a, Identifier b)
        {
            if (ReferenceEquals(null, a))
            {
                return false;
            }

            if (ReferenceEquals(null, b))
            {
                return false;
            }

            if (ReferenceEquals(a, b))
            {
                return true;
            }

            return string.Equals(a.Text, b.Text, StringComparison.InvariantCulture);
        }

        public bool Equals(Identifier other)
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

        public override bool Equals(object obj)
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

            return this.Equals((Identifier)obj);
        }

        public override int GetHashCode()
        {
            return this.Text != null ? this.Text.GetHashCode() : 0;
        }

        public static bool operator ==(Identifier left, Identifier right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Identifier left, Identifier right)
        {
            return Equals(left, right) == false;
        }
    }
}
