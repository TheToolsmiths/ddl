using TheToolsmiths.Ddl.Parser.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Literals;

namespace TheToolsmiths.Ddl.Parser.Models.Enums
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
