using System;
using System.Collections.Generic;
using Ddl.Common;
using Ddl.Resolve.Models.FirstPhase;
using Ddl.Resolve.Models.FirstPhase.Scopes;
using Ddl.Resolve.Models.FirstPhase.TypePaths;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;
using TheToolsmiths.Ddl.Resolve.FirstPhase.ContentItems.Resolvers;
using TheToolsmiths.Ddl.Resolve.FirstPhase.Namespaces;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase
{
    public class FirstPhaseContentUnitCollectionResolver
    {
        private readonly FirstPhaseRootContentItemResolver contentItemResolver;
        private readonly NamespacePathResolver namespacePathResolver;

        public FirstPhaseContentUnitCollectionResolver(
            FirstPhaseRootContentItemResolver contentItemResolver,
            NamespacePathResolver namespacePathResolver)
        {
            this.contentItemResolver = contentItemResolver;
            this.namespacePathResolver = namespacePathResolver;
        }

        public Result ResolveContentUnits(ContentUnitsCollectionResolveContext context, IReadOnlyList<ContentUnit> contentUnits)
        {
            foreach (var contentUnit in contentUnits)
            {
                var result = this.ResolveContentUnit(context, contentUnit);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            return Result.Success;
        }

        private Result ResolveContentUnit(ContentUnitsCollectionResolveContext context, ContentUnit contentUnit)
        {
            FirstPhaseNamespacePath namespacePath;
            {
                var result = this.namespacePathResolver.ResolveContentUnitNamespace(contentUnit.Info);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                namespacePath = result.Value;
            }

            FirstPhaseResolvedScope rootScope;
            {
                var scopeContext = new ContentUnitScopeResolveContext();

                foreach (var contentItem in contentUnit.Items)
                {
                    var result = this.contentItemResolver.ResolveContentItem(scopeContext, contentItem);

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }
                }

                rootScope = scopeContext.BuildResolvedScope();
            }
            
            var resolvedContentUnit = new FirstPhaseResolvedContentUnit(contentUnit.Id, namespacePath, rootScope);

            context.ContentUnits.Add(resolvedContentUnit);

            return Result.Success;
        }
    }
}
