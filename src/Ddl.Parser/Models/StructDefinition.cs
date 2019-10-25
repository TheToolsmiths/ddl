using System;
using System.Collections.Generic;
using System.Text;

namespace TheToolsmiths.Ddl.Parser.Models
{
    public class StructDefinition
    {
        public IReadOnlyList<AttributeUse> Attributes { get; }

        public TypeName Type { get; }

        public IReadOnlyList<FieldDefinition> Fields { get; }
    }
}
