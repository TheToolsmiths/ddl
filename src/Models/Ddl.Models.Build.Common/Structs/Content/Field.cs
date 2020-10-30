using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Build.Values;
using TheToolsmiths.Ddl.Models.Types.Usage;

namespace TheToolsmiths.Ddl.Models.Build.Structs.Content
{
    public class Field : IStructItem
    {
        public Field(
            string name,
            TypeUse fieldType,
            AttributeUseCollection attributes,
            ValueInitialization initialization)
        {
            this.Name = name;
            this.FieldType = fieldType;
            this.Attributes = attributes;
            this.Initialization = initialization;
        }

        public string Name { get; }

        public TypeUse FieldType { get; }

        public AttributeUseCollection Attributes { get; }

        public ValueInitialization Initialization { get; }

        public StructContentItemKind ItemKind => StructContentItemKind.FieldDefinition;
    }
}
