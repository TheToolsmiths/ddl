using TheToolsmiths.Ddl.Models;
using TheToolsmiths.Ddl.Parser.Ast.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Literals;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Enums
{
    public class EnumDefinitionConstantDefinition : IEnumDefinitionItem
    {
        public EnumDefinitionConstantDefinition(Identifier name, LiteralValue literalValue)
        {
            this.Name = name;
            this.LiteralValue = literalValue;
            this.ItemId = ContentUnitSubItemId.CreateNew();
        }

        public ContentUnitSubItemId ItemId { get; }

        public Identifier Name { get; }

        public LiteralValue LiteralValue { get; }

        public EnumDefinitionItemType ItemType => EnumDefinitionItemType.Constant;
    }
}
