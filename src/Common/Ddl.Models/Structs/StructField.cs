using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.Types.References;
using TheToolsmiths.Ddl.Models.Values;

namespace TheToolsmiths.Ddl.Models.Structs
{
    public class StructField : IStructItem
    {
        public StructField(
            string name,
            TypeReference fieldType,
            ValueInitialization initialization,
            AttributeUseCollection attributes)
        {
            this.Attributes = attributes;
            this.Initialization = initialization;
            this.FieldType = fieldType;
            this.Name = name;
        }

        public string Name { get; }

        public TypeReference FieldType { get; }

        public AttributeUseCollection Attributes { get; }

        public ValueInitialization Initialization { get; }

        public StructItemKind ItemKind => StructItemKind.FieldDefinition;
    }
}
