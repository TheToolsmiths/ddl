using TheToolsmiths.Ddl.Models.Build.ImportPaths;

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
