using System;
using System.Collections.Generic;
using System.Linq;

namespace TheToolsmiths.Ddl.Parser.Models.Types.References
{
    public abstract class TypeStorage
    {
        protected TypeStorage(TypeStorageKind storageKind)
        {
            this.StorageKind = storageKind;
        }

        public TypeStorageKind StorageKind { get; }
    }

    public class SingleItemTypeStorage : TypeStorage
    {
        public SingleItemTypeStorage()
            : base(TypeStorageKind.SingleItem)
        {
        }
    }

    public class ArrayTypeStorage : TypeStorage
    {
        private ArrayTypeStorage(IReadOnlyList<ArraySize> sizes, in bool isFixed)
            : base(TypeStorageKind.Array)
        {
            this.Sizes = sizes;
            this.IsFixed = isFixed;
        }

        public IReadOnlyList<ArraySize> Sizes { get; }

        public bool IsFixed { get; }

        public bool IsDynamic => this.IsFixed == false;

        public static ArrayTypeStorage CreateFromSizes(IReadOnlyList<ArraySize> sizes)
        {
            if (sizes.Count == 0)
            {
                throw new ArgumentException(nameof(sizes));
            }

            bool isFixed = sizes.OfType<DynamicArraySize>().Any() == false;

            return new ArrayTypeStorage(sizes, isFixed);
        }
    }

    public abstract class ArraySize
    {
        public abstract override string ToString();
    }

    public class DynamicArraySize : ArraySize
    {
        public override string ToString()
        {
            return "[]";
        }
    }

    public class FixedArraySize : ArraySize
    {
        public FixedArraySize(IReadOnlyList<int> dimensions)
        {
            this.Dimensions = dimensions;
        }

        public IReadOnlyList<int> Dimensions { get; }

        public override string ToString()
        {
            return $"[{string.Join(", ", this.Dimensions.Select(d => d.ToString()))}]";
        }
    }
}
