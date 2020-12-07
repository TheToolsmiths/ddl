using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Models
{
    public static class CommonItemTypes
    {
        public static ItemType EnumDefinition { get; } = new("enum/def");

        public static ItemType EnumStructDefinition { get; } = new("enum-struct/def");

        public static ItemType StructDefinition { get; } = new("struct/def");

        public static ItemType ImportStatement { get; } = new("import/statement");
    }
}
