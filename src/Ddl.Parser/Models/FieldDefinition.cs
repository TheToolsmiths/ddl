using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Parser.Models
{
    public class FieldDefinition
    {
        public IReadOnlyList<AttributeUse> Attributes { get; }

        public string Name { get; }
        
        public TypeName Type { get; }

        public ValueInitialization Initialization { get; set; }
    }
}