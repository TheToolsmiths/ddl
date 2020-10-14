using System;
using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Build.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.TypeResolver.Contexts;
using TheToolsmiths.Ddl.Parser.TypeResolver.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.Implementations
{
    internal class ConditionalRootScopeTypeResolver : IScopeTypeResolver<ConditionalRootScope>
    {
        public RootScopeTypeResolveResult ResolveScopeTypes(IRootScopeTypeResolveContext scopeContext, ConditionalRootScope scope)
        {
            ScopeContent scopeContent;
            {
                var result = scopeContext.CommonTypeResolvers.ResolveScopeContent(scope.Content);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                scopeContent = result.Value;
            }

            AttributeUseCollection attributes;
            {
                var result = scopeContext.CommonTypeResolvers.ResolveAttributes(scope.Attributes);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                attributes = result.Value;
            }

            var resolvedScope = new ConditionalRootScope(scope.ConditionalExpression, scopeContent, attributes);

            return new RootScopeTypeResolveSuccess(resolvedScope);
        }
    }
}
