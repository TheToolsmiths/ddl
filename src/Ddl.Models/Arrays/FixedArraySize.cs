using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.Arrays
{
    public class FixedArraySize : ArraySize
    {
        public FixedArraySize(List<string> dimensions)
        {
            this.Dimensions = dimensions;
        }

        public IReadOnlyList<string> Dimensions { get; }
    }
}
