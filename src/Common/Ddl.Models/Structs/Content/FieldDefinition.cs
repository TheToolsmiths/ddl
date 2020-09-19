using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.Types.References;
using TheToolsmiths.Ddl.Models.Values;

namespace TheToolsmiths.Ddl.Models.Structs.Content
{
    public class FieldDefinition : IStructDefinitionItem
    {
        public FieldDefinition(
            string name,
            TypeReference fieldType,
            AttributeUseCollection attributes,
            ValueInitialization initialization)
        {
            this.Name = name;
            this.FieldType = fieldType;
            this.Attributes = attributes;
            this.Initialization = initialization;
        }

        public string Name { get; }

        public TypeReference FieldType { get; }

        public AttributeUseCollection Attributes { get; }

        public ValueInitialization Initialization { get; }

        public StructDefinitionItemKind ItemKind => StructDefinitionItemKind.FieldDefinition;
    }
}
