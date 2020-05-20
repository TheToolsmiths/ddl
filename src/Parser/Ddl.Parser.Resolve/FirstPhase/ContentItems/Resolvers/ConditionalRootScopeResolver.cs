using System.Collections.Generic;
using Ddl.Common;
using Ddl.Parser.Resolve.Models.FirstPhase.Scopes;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase.ContentItems.Resolvers
{
    public class ConditionalRootScopeResolver : IRootContentScopeResolver<ConditionalRootScope>
    {
        private readonly ScopeContentResolver scopeResolver;

        public ConditionalRootScopeResolver(ScopeContentResolver scopeResolver)
        {
            this.scopeResolver = scopeResolver;
        }

        public Result CatalogScope(ContentUnitScopeResolveContext unitContext, ConditionalRootScope scope)
        {
            var additionalProperties = new List<FirstPhaseResolvedScopeProperty>();

            if (scope.ConditionalExpression.IsEmpty == false)
            {
                additionalProperties.Add(new ConditionalProperty(scope.ConditionalExpression));
            }

            var scopeContext = unitContext.CreateScopeWithAdditionalProperties(additionalProperties);

            var result = this.scopeResolver.ResolveScopeContent(scopeContext, scope.Content);

            if (result.IsError)
            {
                throw new System.NotImplementedException();
            }

            var resolvedScope = result.Value;

            unitContext.ResolvedScopes.Add(resolvedScope);

            return Result.Success;
        }
    }
}
