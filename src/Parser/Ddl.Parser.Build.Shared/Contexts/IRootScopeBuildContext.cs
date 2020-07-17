namespace TheToolsmiths.Ddl.Parser.Build.Contexts
{
    public interface IRootScopeBuildContext : IRootEntryBuildContext
    {
        IRootScopeBuildContext CreateScopeContext();

        IRootItemBuildContext CreateItemContext();
    }
}
