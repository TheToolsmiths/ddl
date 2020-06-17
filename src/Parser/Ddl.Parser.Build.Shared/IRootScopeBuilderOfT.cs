using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Results;

namespace TheToolsmiths.Ddl.Parser.Build
{
    public interface IRootScopeBuilder<TAstScope> : IRootScopeBuilder
        where TAstScope : class, IAstRootScope
    {
        public RootScopeBuildResult BuildScope(IRootItemBuildContext unitContext, TAstScope scope);
    }

    public interface IRootScopeBuilder
    {
    }
}
