using System;

using TheToolsmiths.Ddl.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.TypeResolver.Contexts;
using TheToolsmiths.Ddl.Parser.TypeResolver.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.Implementations
{
    internal class RootScopeTypeResolver : IScopeTypeResolver<RootScope>
    {
        public RootScopeTypeResolveResult ResolveScopeTypes(IRootScopeTypeResolveContext scopeContext, RootScope scope)
        {
            var result = scopeContext.CommonTypeResolvers.ResolveScopeContent(scope.Content);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var scopeContent = result.Value;

            var resolvedScope = new RootScope(scopeContent);

            return new RootScopeTypeResolveSuccess(resolvedScope);
        }
    }
}
