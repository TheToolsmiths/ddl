using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;
using TheToolsmiths.Ddl.Models.Compiled.Types.References;
using TheToolsmiths.Ddl.Models.Compiled.Values;

namespace TheToolsmiths.Ddl.Models.Compiled.Structs.Content
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
