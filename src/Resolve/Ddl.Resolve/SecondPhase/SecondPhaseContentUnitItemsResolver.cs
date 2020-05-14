﻿using System;
using Ddl.Common;
using Ddl.Resolve.Models.FirstPhase;
using TheToolsmiths.Ddl.Resolve.SecondPhase.ContentItems.Resolvers;

namespace TheToolsmiths.Ddl.Resolve.SecondPhase
{
    public class SecondPhaseContentUnitItemsResolver
    {
        private readonly RootScopeResolver rootScopeResolver;

        public SecondPhaseContentUnitItemsResolver(RootScopeResolver rootScopeResolver)
        {
            this.rootScopeResolver = rootScopeResolver;
        }

        public Result ResolveContentUnit(
            ContentUnitResolveContext context,
            FirstPhaseResolvedContentUnit contentUnit)
        {
            var rootScope = contentUnit.RootScope;

            var scopeContext = ScopeItemResolveContext.CreateForRoot(contentUnit.IndexedTypes);

            {
                var result = this.rootScopeResolver.CatalogScope(scopeContext, rootScope);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            return Result.Success;
        }
    }
}
