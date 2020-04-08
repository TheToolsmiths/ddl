using TheToolsmiths.Ddl.Models.Identifiers;

namespace TheToolsmiths.Ddl.Models.Enums
{
    public class EnumDefinitionConstantDefinition : IEnumDefinitionItem
    {
        public EnumDefinitionConstantDefinition(Identifier name)
        {
            this.Name = name;
        }

        public Identifier Name { get; }

        public EnumDefinitionItemType ItemType => EnumDefinitionItemType.Constant;
    }
}
