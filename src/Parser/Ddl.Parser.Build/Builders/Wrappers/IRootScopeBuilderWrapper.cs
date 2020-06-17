using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Results;

namespace TheToolsmiths.Ddl.Parser.Build.Builders.Wrappers
{
    internal interface IRootScopeBuilderWrapper
    {
        RootScopeBuildResult BuildScope(IRootItemBuildContext context, IAstRootScope scope);
    }
}
