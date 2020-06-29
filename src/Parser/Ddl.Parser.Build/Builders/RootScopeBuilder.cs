using System;

using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Build.Builders
{
    internal class RootScopeBuilder
    {
        private readonly RootBuilderResolver builderResolver;

        public RootScopeBuilder(RootBuilderResolver builderResolver)
        {
            this.builderResolver = builderResolver;
        }

        public Result BuildScope(ContentUnitScopeBuildContext context, IAstRootScope scope)
        {
            if (this.builderResolver.TryResolveScopeBuilder(scope, out var scopeBuilder) == false)
            {
                throw new NotImplementedException();
            }

            var result = scopeBuilder.BuildScope(context, scope);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            throw new NotImplementedException();
            return Result.Success;
        }
    }
}
