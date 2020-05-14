using System;
using Ddl.Common;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase.ContentItems.Resolvers
{
    public class RootScopeResolver
    {
        private readonly ContentUnitEntityResolverProvider resolverProvider;

        public RootScopeResolver(ContentUnitEntityResolverProvider resolverProvider)
        {
            this.resolverProvider = resolverProvider;
        }

        public Result ResolveScope(ContentUnitScopeResolveContext context, IRootScope item)
        {
            var result = item switch
            {
                ConditionalRootScope rootScope => this.resolverProvider.CreateRootScopeResolver()
                    .CatalogScope(context, rootScope),

                _ => throw new ArgumentOutOfRangeException(nameof(item))
            };

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            return Result.Success;
        }
    }
}
