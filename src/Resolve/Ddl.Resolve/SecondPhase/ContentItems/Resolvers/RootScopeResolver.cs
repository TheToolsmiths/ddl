using System;
using System.Collections.Generic;
using Ddl.Common;
using Ddl.Resolve.Models.FirstPhase.Items;
using Ddl.Resolve.Models.FirstPhase.Scopes;

namespace TheToolsmiths.Ddl.Resolve.SecondPhase.ContentItems.Resolvers
{
    public class RootScopeResolver
    {
        private readonly SecondPhaseRootContentItemResolver contentItemResolver;

        public RootScopeResolver(SecondPhaseRootContentItemResolver contentItemResolver)
        {
            this.contentItemResolver = contentItemResolver;
        }

        public Result CatalogScope(ContentUnitScopeResolveContext unitContext, FirstPhaseResolvedScope rootScope)
        {
            {
                var result = this.CatalogScopeItems(unitContext, rootScope.ResolvedItems);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            {
                var result = this.CatalogChildScopes(unitContext, rootScope.ResolvedScopes);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            return Result.Success;
        }

        private Result CatalogChildScopes(ContentUnitScopeResolveContext unitContext, IReadOnlyList<FirstPhaseResolvedScope> scopes)
        {
            throw new NotImplementedException();
        }

        private Result CatalogScopeItems(ContentUnitScopeResolveContext unitContext, IReadOnlyList<FirstPhaseResolvedItem> items)
        {
            var scopeContext = new ContentUnitScopeResolveContext();

            foreach (var contentItem in items)
            {
                var result = this.contentItemResolver.ResolveContentItem(scopeContext, contentItem);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            throw new NotImplementedException();
        }
    }
}
