using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Models
{
    public static class CommonSubItemTypes
    {
        public static SubItemType EnumConstantDefinition { get; } = new(CommonItemTypes.EnumDefinition, "constant");

        public static SubItemType EnumStructVariantDefinition { get; } = new(CommonItemTypes.EnumStructDefinition, "variant");
    }
}
