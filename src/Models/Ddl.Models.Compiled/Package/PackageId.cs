using System;

namespace TheToolsmiths.Ddl.Models.Compiled.Package
{
    public readonly struct PackageId : IEquatable<PackageId>
    {
        private static int nextId;

        private readonly int value;

        private PackageId(int value)
        {
            this.value = value;
        }

        public static PackageId CreateNew() => new PackageId(nextId++);

        public bool Equals(PackageId other)
        {
            return this.value == other.value;
        }

        public override bool Equals(object? obj)
        {
            return obj is PackageId other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return this.value;
        }

        public static bool operator ==(PackageId left, PackageId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PackageId left, PackageId right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return $"Item Id '{this.value}'";
        }
    }
}
