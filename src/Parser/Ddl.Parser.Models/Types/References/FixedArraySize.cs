using System.Collections.Generic;
using System.Linq;

namespace TheToolsmiths.Ddl.Parser.Models.Types.References
{
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