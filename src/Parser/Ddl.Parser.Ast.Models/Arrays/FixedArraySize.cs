using System.Collections.Generic;
using System.Linq;

using TheToolsmiths.Ddl.Parser.Models.Literals;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Arrays
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
