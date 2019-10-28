using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Parser.Models
{
    public class FieldDefinition
    {
        public FieldDefinition(
            FieldName name,
            TypeIdentifier type,
            ValueInitialization initialization,
            IReadOnlyList<AttributeUse> attributes)
        {
            Attributes = attributes;
            Initialization = initialization;
            Type = type;
            Name = name;
        }

        public FieldName Name { get; }

        public TypeIdentifier Type { get; }

        public IReadOnlyList<AttributeUse> Attributes { get; }

        public ValueInitialization Initialization { get; }
    }
}
