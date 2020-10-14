namespace TheToolsmiths.Ddl.Models.Ast.EntryTypes
{
    public static class CommonScopeTypes
    {
        public static AstScopeType ConditionalScope { get; } = new AstScopeType("scope/root-conditional");

        public static AstScopeType RootScope { get; } = new AstScopeType("scope/root");
    }
}
