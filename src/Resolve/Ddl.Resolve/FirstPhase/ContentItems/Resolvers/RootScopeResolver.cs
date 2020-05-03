using System;
using System.Collections.Generic;
using Ddl.Common;
using Ddl.Resolve.Models.FirstPhase.Scopes;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase.ContentItems.Resolvers
{
    public class RootScopeResolver : IRootContentItemResolver<RootScope>
    {
        private readonly FirstPhaseRootContentItemResolver contentItemResolver;

        public RootScopeResolver(FirstPhaseRootContentItemResolver contentItemResolver)
        {
            this.contentItemResolver = contentItemResolver;
        }

        public Result CatalogItem(ContentUnitScopeResolveContext unitContext, RootScope rootScope)
        {
            var properties = new List<FirstPhaseResolvedScopeProperty>();

            if (rootScope.ConditionalExpression.IsEmpty == false)
            {
                properties.Add(new ConditionalProperty(rootScope.ConditionalExpression));
            }

            var scopeContext = new ContentUnitScopeResolveContext(properties);
            foreach (var contentItem in rootScope.ContentItems)
            {
                var result = this.contentItemResolver.ResolveContentItem(scopeContext, contentItem);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            var scope = scopeContext.BuildResolvedScope();

            unitContext.ResolvedScopes.Add(scope);

            return Result.Success;
        }
    }
}
