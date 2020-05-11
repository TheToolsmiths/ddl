using System;
using Ddl.Common;
using Ddl.Resolve.Models.FirstPhase;
using Ddl.Resolve.Models.FirstPhase.Scopes;
using Ddl.Resolve.Models.FirstPhase.TypePaths;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;
using TheToolsmiths.Ddl.Resolve.FirstPhase.ContentItems.Resolvers;
using TheToolsmiths.Ddl.Resolve.FirstPhase.Namespaces;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase
{
    public class FirstPhaseContentUnitResolver
    {
        private readonly FirstPhaseRootContentItemResolver contentItemResolver;
        private readonly NamespacePathResolver namespacePathResolver;
        private readonly FirstPhaseContentUnitTypeIndexer typeIndexer;

        public FirstPhaseContentUnitResolver(
            FirstPhaseContentUnitTypeIndexer typeIndexer,
            FirstPhaseRootContentItemResolver contentItemResolver,
            NamespacePathResolver namespacePathResolver)
        {
            this.typeIndexer = typeIndexer;
            this.contentItemResolver = contentItemResolver;
            this.namespacePathResolver = namespacePathResolver;
        }

        public Result<FirstPhaseResolvedContentUnit> ResolveContentUnit(ContentUnit contentUnit)
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

            throw new System.NotImplementedException();

            //FirstPhaseResolvedScope rootScope;
            //{
            //    var scopeContext = ContentUnitScopeResolveContext.CreateRootContext(namespacePath);

            //    foreach (var contentItem in contentUnit.Items)
            //    {
            //        var result = this.contentItemResolver.ResolveContentItem(scopeContext, contentItem);

            //        if (result.IsError)
            //        {
            //            throw new NotImplementedException();
            //        }
            //    }

            //    rootScope = scopeContext.BuildResolvedScope();
            //}

            //var resolvedContentUnit = new FirstPhaseResolvedContentUnit(contentUnit.Id, namespacePath, rootScope);

            //return Result.FromValue(resolvedContentUnit);
        }
    }
}
