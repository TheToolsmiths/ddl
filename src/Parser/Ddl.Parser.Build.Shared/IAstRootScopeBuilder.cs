using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Results;

namespace TheToolsmiths.Ddl.Parser.Build
{
    public interface IAstRootScopeBuilder
    {
        RootScopeBuildResult BuildScope(IRootScopeBuildContext context, IAstRootScope scope);
    }
}
