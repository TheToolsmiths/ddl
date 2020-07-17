using System;

using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Results;

namespace TheToolsmiths.Ddl.Parser.Build.Builders
{
    internal class AstRootScopeBuilder : IAstRootScopeBuilder
    {
        private readonly RootBuilderResolver builderResolver;

        public AstRootScopeBuilder(RootBuilderResolver builderResolver)
        {
            this.builderResolver = builderResolver;
        }

        public RootScopeBuildResult BuildScope(IRootScopeBuildContext context, IAstRootScope scope)
        {
            if (this.builderResolver.TryResolveScopeBuilder(scope, out var scopeBuilder) == false)
            {
                throw new NotImplementedException();
            }

            return scopeBuilder.BuildScope(context, scope);
        }
    }
}
