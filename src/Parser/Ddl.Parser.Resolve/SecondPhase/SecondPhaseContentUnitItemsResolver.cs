using System;
using Ddl.Common;
using Ddl.Parser.Resolve.Models.FirstPhase;
using TheToolsmiths.Ddl.Resolve.SecondPhase.ContentItems.Resolvers;

namespace TheToolsmiths.Ddl.Resolve.SecondPhase
{
    public class SecondPhaseContentUnitItemsResolver
    {
        private readonly RootScopeResolver rootScopeResolver;
        private readonly IServiceProvider serviceProvider;

        public SecondPhaseContentUnitItemsResolver(
            RootScopeResolver rootScopeResolver,
            IServiceProvider serviceProvider)
        {
            this.rootScopeResolver = rootScopeResolver;
            this.serviceProvider = serviceProvider;
        }

        public Result ResolveContentUnit(ContentUnitResolveContext context, FirstPhaseResolvedContentUnit contentUnit)
        {
            var rootScope = contentUnit.RootScope;

            var scopeContext = ScopeItemResolveContext.CreateForRoot(
                contentUnit.NamespacePath,
                contentUnit.IndexedTypes,
                this.serviceProvider);

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
