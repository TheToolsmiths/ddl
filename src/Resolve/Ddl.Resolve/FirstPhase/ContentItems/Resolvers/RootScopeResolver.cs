using System;
using System.Collections.Generic;
using Ddl.Common;
using Ddl.Resolve.Models.FirstPhase.Scopes;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase.ContentItems.Resolvers
{
    public class RootScopeResolver : IRootContentScopeResolver<ConditionalRootScope>
    {
        private readonly FirstPhaseRootContentItemResolver contentItemResolver;

        public RootScopeResolver(FirstPhaseRootContentItemResolver contentItemResolver)
        {
            this.contentItemResolver = contentItemResolver;
        }

        public Result CatalogScope(ContentUnitScopeResolveContext unitContext, ConditionalRootScope item)
        {
            var additionalProperties = new List<FirstPhaseResolvedScopeProperty>();

            if (item.ConditionalExpression.IsEmpty == false)
            {
                additionalProperties.Add(new ConditionalProperty(item.ConditionalExpression));
            }

            throw new System.NotImplementedException();

            //var scopeContext = unitContext.CreateScopeWithAdditionalProperties(additionalProperties);

            //foreach (var contentItem in item.ContentItems)
            //{
            //    var result = this.contentItemResolver.ResolveContentItem(scopeContext, contentItem);

            //    if (result.IsError)
            //    {
            //        throw new NotImplementedException();
            //    }
            //}

            //var scope = scopeContext.BuildResolvedScope();

            //unitContext.ResolvedScopes.Add(scope);

            //return Result.Success;
        }
    }
}
