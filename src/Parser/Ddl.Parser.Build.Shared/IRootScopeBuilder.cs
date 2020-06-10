using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Results;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Parser.Build
{
    public interface IRootScopeBuilder<T>
        where T : class, IRootScope
    {
        public RootScopeBuildResult<T> CatalogScope(IRootItemBuildContext unitContext, IAstRootScope scope);
    }
}
