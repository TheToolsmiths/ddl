namespace TheToolsmiths.Ddl.Models.Ast.EntryTypes
{
    public static class CommonItemTypes
    {
        public static AstItemType EnumDeclaration { get; } = new AstItemType("enum/declaration");

        public static AstItemType EnumStructDeclaration { get; } = new AstItemType("enum-struct/declaration");

        public static AstItemType StructDeclaration { get; } = new AstItemType("struct/declaration");

        public static AstItemType ImportStatement { get; } = new AstItemType("import/statement");
    }
}
