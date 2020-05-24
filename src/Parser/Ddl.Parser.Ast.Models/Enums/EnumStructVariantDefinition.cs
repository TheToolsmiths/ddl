using Ddl.Common.Models;
using TheToolsmiths.Ddl.Parser.Ast.Models.Structs;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Enums
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
