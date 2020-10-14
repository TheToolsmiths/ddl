namespace TheToolsmiths.Ddl.Models.Compiled.EntryTypes
{
    public static class CommonItemTypes
    {
        public static ItemType EnumDefinition { get; } = new ItemType("enum/definition");

        public static ItemType EnumStructDefinition { get; } = new ItemType("enum-struct/definition");

        public static ItemType StructDefinition { get; } = new ItemType("struct/definition");

        public static ItemType ImportStatement { get; } = new ItemType("import/statement");
    }
}
