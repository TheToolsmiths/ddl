using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.Ast.Literals;

namespace TheToolsmiths.Ddl.Models.Ast.Arrays
{
    public class FixedArraySize : ArraySize
    {
        public FixedArraySize(IReadOnlyList<NumberLiteral> dimensions)
        {
            this.Dimensions = dimensions;
        }

        public IReadOnlyList<NumberLiteral> Dimensions { get; }

        public override string ToString()
        {
            return $"[{string.Join(", ", this.Dimensions.Select(nl => nl.Text))}]";
        }
    }
}
