using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Models
{
    public static class CommonSubItemTypes
    {
        public static SubItemType EnumConstantDefinition { get; } = new SubItemType("enum/constant/definition");

        public static SubItemType EnumStructVariantDefinition { get; } = new SubItemType("enum-struct/variant/definition");
    }
}
