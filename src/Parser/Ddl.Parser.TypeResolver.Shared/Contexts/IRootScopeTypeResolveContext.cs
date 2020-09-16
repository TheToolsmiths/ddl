namespace TheToolsmiths.Ddl.Parser.TypeResolver.Contexts
{
    public interface IRootScopeTypeResolveContext : IRootEntryTypeResolveContext
    {
        IRootScopeTypeResolveContext CreateScopeContext();

        IRootItemTypeResolveContext CreateItemContext();
    }
}
