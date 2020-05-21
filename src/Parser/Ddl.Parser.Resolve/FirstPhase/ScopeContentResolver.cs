using System;
using Ddl.Common;
using Ddl.Parser.Resolve.Models.FirstPhase.Scopes;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Resolve.FirstPhase.ContentItems.Resolvers;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase
{
    public class ScopeContentResolver
    {
        private readonly RootItemResolver itemResolver;
        private readonly RootScopeResolver scopeResolver;

        public ScopeContentResolver(
            RootItemResolver itemResolver,
            RootScopeResolver scopeResolver)
        {
            this.itemResolver = itemResolver;
            this.scopeResolver = scopeResolver;
        }

        public Result<FirstPhaseResolvedScope> ResolveScopeContent(
            ContentUnitScopeResolveContext parentContext,
            ScopeContent scopeContent)
        {
            var scopeContext = parentContext.CreateChildContext();

            foreach (var item in scopeContent.Items)
            {
                var result = this.itemResolver.ResolveItem(scopeContext, item);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            foreach (var scope in scopeContent.Scopes)
            {
                var result = this.scopeResolver.ResolveScope(scopeContext, scope);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            var rootScope = scopeContext.BuildResolvedScope();

            return Result.FromValue(rootScope);
        }
    }
}
