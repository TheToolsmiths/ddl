using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Arrays
{
    public class FixedArraySize : ArraySize
    {
        public FixedArraySize(IReadOnlyList<string> dimensions)
        {
            this.Dimensions = dimensions;
        }

        public IReadOnlyList<string> Dimensions { get; }
    }
}
