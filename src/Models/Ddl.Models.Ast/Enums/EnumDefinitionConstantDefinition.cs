using TheToolsmiths.Ddl.Models.Ast.Identifiers;
using TheToolsmiths.Ddl.Models.Ast.Literals;

namespace TheToolsmiths.Ddl.Models.Ast.Enums
{
    public class EnumDefinitionConstantDefinition : IEnumDefinitionItem
    {
        public EnumDefinitionConstantDefinition(Identifier name, LiteralValue literalValue)
        {
            this.Name = name;
            this.LiteralValue = literalValue;
        }

        public Identifier Name { get; }

        public LiteralValue LiteralValue { get; }

        public EnumDefinitionItemType ItemType => EnumDefinitionItemType.Constant;
    }
}
