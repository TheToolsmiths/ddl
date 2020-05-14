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

        public Result CatalogScope(ScopeItemResolveContext parentScopeContext, FirstPhaseResolvedScope rootScope)
        {
            var scopeContext = parentScopeContext.CreateChildScope(rootScope.ImportPaths);

            {
                var result = this.CatalogScopeItems(scopeContext, rootScope.Items);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            foreach (var childScope in rootScope.Scopes)
            {
                var result = this.CatalogScope(scopeContext, childScope);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            return Result.Success;
        }

        private Result CatalogScopeItems(ScopeItemResolveContext scopeContext, IReadOnlyList<FirstPhaseResolvedItem> items)
        {
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
