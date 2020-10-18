using System;
using System.Collections.Generic;
using System.Linq;

namespace TheToolsmiths.Ddl.Models.Types.Usage.Storage
{
    public class ArrayTypeUseStorage : TypeUseStorage
    {
        private ArrayTypeUseStorage(IReadOnlyList<ArraySize> sizes, in bool isFixed)
            : base(TypeStorageUseKind.Array)
        {
            this.Sizes = sizes;
            this.IsFixed = isFixed;
        }

        public IReadOnlyList<ArraySize> Sizes { get; }

        public bool IsFixed { get; }

        public bool IsDynamic => this.IsFixed == false;

        public static ArrayTypeUseStorage CreateFromSizes(params ArraySize[] sizes)
        {
            return CreateFromSizes((IReadOnlyList<ArraySize>)sizes);
        }

        public static ArrayTypeUseStorage CreateFromSizes(IReadOnlyList<ArraySize> sizes)
        {
            if (sizes.Count == 0)
            {
                throw new ArgumentException(nameof(sizes));
            }

            bool isFixed = sizes.OfType<DynamicArraySize>().Any() == false;

            return new ArrayTypeUseStorage(sizes, isFixed);
        }
    }
}
