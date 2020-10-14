using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Build.Types.References;
using TheToolsmiths.Ddl.Models.Build.Values;

namespace TheToolsmiths.Ddl.Models.Build.Structs.Content
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
