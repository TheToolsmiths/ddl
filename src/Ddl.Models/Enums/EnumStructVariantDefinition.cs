using TheToolsmiths.Ddl.Models.Identifiers;
using TheToolsmiths.Ddl.Models.Structs;

namespace TheToolsmiths.Ddl.Models.Enums
{
    public class EnumStructVariantDefinition : IEnumStructDefinitionItem
    {
        public EnumStructVariantDefinition(Identifier name, StructDefinitionContent content)
        {
            this.Name = name;
            this.Content = content;
        }

        public Identifier Name { get; }

        public StructDefinitionContent Content { get; }

        public EnumStructDefinitionItemType ItemType => EnumStructDefinitionItemType.VariantDefinition;
    }
}
