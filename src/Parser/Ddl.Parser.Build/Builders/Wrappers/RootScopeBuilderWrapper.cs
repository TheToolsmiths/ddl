using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Results;

namespace TheToolsmiths.Ddl.Parser.Build.Builders.Wrappers
{
    internal class RootScopeBuilderWrapper<TBuilder, TAstScope> : RootScopeBuilderWrapper
        where TBuilder : IRootScopeBuilder<TAstScope>
        where TAstScope : class, IAstRootScope
    {
        private readonly TBuilder builder;

        public RootScopeBuilderWrapper(TBuilder builder)
        {
            this.builder = builder;
        }

        public override RootScopeBuildResult BuildScope(IRootItemBuildContext context, IAstRootScope scope)
        {
            return this.builder.BuildScope(context, (TAstScope)scope);
        }
    }

    internal abstract class RootScopeBuilderWrapper
    {
        public abstract RootScopeBuildResult BuildScope(IRootItemBuildContext context, IAstRootScope scope);
    }
}
