using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Parser.Models
{
    public class StructDefinition
    {
        public StructDefinition(
            TypeName typeName,
            IReadOnlyList<AttributeUse> attributes,
            IReadOnlyList<FieldDefinition> structFields)
        {
            TypeName = typeName;
            Attributes = attributes;
            Fields = structFields;
        }

        public IReadOnlyList<AttributeUse> Attributes { get; }

        public TypeName TypeName { get; }

        public IReadOnlyList<FieldDefinition> Fields { get; }
    }
}
