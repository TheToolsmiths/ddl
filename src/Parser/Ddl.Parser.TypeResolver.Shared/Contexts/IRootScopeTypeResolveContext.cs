using TheToolsmiths.Ddl.Models.ImportPaths;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.Contexts
{
    public interface IRootScopeTypeResolveContext : IRootEntryTypeResolveContext
    {
        IRootScopeTypeResolveContext CreateScopeContext();

        IRootItemTypeResolveContext CreateItemContext();

        IRootScopeTypeResolveContext AddImportPaths(
            IRootScopeTypeResolveContext context,
            ImportStatementCollection imports);
    }
}
