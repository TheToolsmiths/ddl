using System;
using System.Diagnostics;

namespace TheToolsmiths.Ddl.Models.Compiled.ContentUnits
{
    [DebuggerDisplay("Item Id '{" + nameof(value) + "}'")]
    public readonly struct ItemId : IEquatable<ItemId>
    {
        private static int nextId;

        private readonly int value;

        private ItemId(int value)
        {
            this.value = value;
        }

        public static ItemId CreateNew() => new ItemId(nextId++);

        public bool Equals(ItemId other)
        {
            return this.value == other.value;
        }

        public override bool Equals(object? obj)
        {
            return obj is ItemId other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return this.value;
        }

        public static bool operator ==(ItemId left, ItemId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ItemId left, ItemId right)
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
