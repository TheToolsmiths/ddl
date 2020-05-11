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
    //public class FirstPhaseContentUnitItemsResolver
    //{
    //    private readonly FirstPhaseRootContentItemResolver contentItemResolver;
    //    private readonly NamespacePathResolver namespacePathResolver;

    //    public FirstPhaseContentUnitItemsResolver(
    //        FirstPhaseRootContentItemResolver contentItemResolver,
    //        NamespacePathResolver namespacePathResolver)
    //    {
    //        this.contentItemResolver = contentItemResolver;
    //        this.namespacePathResolver = namespacePathResolver;
    //    }

    //    public Result<FirstPhaseResolvedContentUnit> ResolveContentUnit(ContentUnitResolveContext context, ContentUnit contentUnit)
    //    {
    //        FirstPhaseNamespacePath namespacePath;
    //        {
    //            var result = this.namespacePathResolver.ResolveContentUnitNamespace(contentUnit.Info);

    //            if (result.IsError)
    //            {
    //                throw new NotImplementedException();
    //            }

    //            namespacePath = result.Value;
    //        }

    //        FirstPhaseResolvedScope rootScope;
    //        {
    //            var scopeContext = new ContentUnitScopeResolveContext();

    //            foreach (var contentItem in contentUnit.Items)
    //            {
    //                var result = this.contentItemResolver.ResolveContentItem(scopeContext, contentItem);

    //                if (result.IsError)
    //                {
    //                    throw new NotImplementedException();
    //                }
    //            }

    //            rootScope = scopeContext.BuildResolvedScope();
    //        }

    //        var resolvedContentUnit = new FirstPhaseResolvedContentUnit(contentUnit.Id, namespacePath, rootScope);

    //        return Result.FromValue(resolvedContentUnit);
    //    }
    //}
}
