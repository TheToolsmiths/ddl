using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Models.Types;
using TheToolsmiths.Ddl.Parser.Models.Types.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Values;

namespace TheToolsmiths.Ddl.Parser.Models.Structs
{
    public class FieldDefinition : IStructDefinitionItem
    {
        public FieldDefinition(
            FieldName name,
            ITypeIdentifier fieldType,
            ValueInitialization initialization,
            IReadOnlyList<IAttributeUse> attributes)
        {
            this.Attributes = attributes;
            this.Initialization = initialization;
            this.FieldType = fieldType;
            this.Name = name;
        }

        public FieldName Name { get; }

        public ITypeIdentifier FieldType { get; }

        public IReadOnlyList<IAttributeUse> Attributes { get; }

        public ValueInitialization Initialization { get; }

        public StructDefinitionItemType ItemType => StructDefinitionItemType.FieldDefinition;
    }
}
