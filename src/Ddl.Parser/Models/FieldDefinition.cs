using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Parser.Models
{
    public class FieldDefinition : IStructDefinitionItem
    {
        public FieldDefinition(
            FieldName name,
            TypeIdentifier type,
            ValueInitialization initialization,
            IReadOnlyList<IAttributeUse> attributes)
        {
            Attributes = attributes;
            Initialization = initialization;
            Type = type;
            Name = name;
        }

        public FieldName Name { get; }

        public TypeIdentifier Type { get; }

        public IReadOnlyList<IAttributeUse> Attributes { get; }

        public ValueInitialization Initialization { get; }

        public StructDefinitionItemType ItemType => StructDefinitionItemType.FieldDefinition;
    }
}
