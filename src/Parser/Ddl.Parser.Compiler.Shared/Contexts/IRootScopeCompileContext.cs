using TheToolsmiths.Ddl.Models.Build.ImportPaths;

namespace TheToolsmiths.Ddl.Parser.Compiler.Contexts
{
    public interface IRootScopeCompileContext : IRootEntryTypeResolveContext
    {
        IRootScopeCompileContext CreateScopeContext();

        IRootItemCompileContext CreateItemContext();

        IRootScopeCompileContext AddImportPaths(
            IRootScopeCompileContext context,
            ImportStatementCollection imports);
    }
}
