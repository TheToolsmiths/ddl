using Ddl.Common.Models;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Structs;

namespace TheToolsmiths.Ddl.Parser.Models.Enums
{
    public class EnumStructVariantDefinition : IEnumStructDefinitionItem
    {
        public EnumStructVariantDefinition(Identifier name, StructDefinitionContent content)
        {
            this.Name = name;
            this.Content = content;
            this.ItemId = ContentUnitSubItemId.CreateNew();
        }

        public ContentUnitSubItemId ItemId { get; }

        public Identifier Name { get; }

        public StructDefinitionContent Content { get; }

        public EnumStructDefinitionItemType ItemType => EnumStructDefinitionItemType.VariantDefinition;
    }
}
