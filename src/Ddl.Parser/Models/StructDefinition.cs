using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Parser.Models
{
    public class StructDefinition
    {
        public StructDefinition(
            TypeName typeName,
            IReadOnlyList<IAttributeUse> attributes,
            IReadOnlyList<FieldDefinition> structFields)
        {
            TypeName = typeName;
            Attributes = attributes;
            Fields = structFields;
        }

        public IReadOnlyList<IAttributeUse> Attributes { get; }

        public TypeName TypeName { get; }

        public IReadOnlyList<FieldDefinition> Fields { get; }
    }
}
