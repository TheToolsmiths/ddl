using System;
using System.Collections.Generic;
using System.Linq;

namespace TheToolsmiths.Ddl.Models.Compiled.Types.References.Storage
{
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

        public static ArrayTypeStorage CreateFromSizes(params ArraySize[] sizes)
        {
            return CreateFromSizes((IReadOnlyList<ArraySize>)sizes);
        }

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
}
