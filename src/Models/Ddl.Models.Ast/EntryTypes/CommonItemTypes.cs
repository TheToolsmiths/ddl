namespace TheToolsmiths.Ddl.Models.Ast.EntryTypes
{
    public static class CommonItemTypes
    {
        public static AstItemType EnumDeclaration { get; } = new("enum/declaration");

        public static AstItemType EnumStructDeclaration { get; } = new("enum-struct/declaration");

        public static AstItemType StructDeclaration { get; } = new("struct/declaration");

        public static AstItemType ImportStatement { get; } = new("import/statement");
    }
}
