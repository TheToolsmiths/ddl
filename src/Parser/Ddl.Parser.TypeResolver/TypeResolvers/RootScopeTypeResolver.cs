using System;
using TheToolsmiths.Ddl.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.TypeResolver.Contexts;
using TheToolsmiths.Ddl.Parser.TypeResolver.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.TypeResolvers
{
    internal class RootScopeTypeResolver : IRootScopeTypeResolver
    {
        private readonly RootTypeResolverResolver typeResolverResolver;

        public RootScopeTypeResolver(RootTypeResolverResolver typeResolverResolver)
        {
            this.typeResolverResolver = typeResolverResolver;
        }

        public RootScopeTypeResolveResult ResolveScopeTypes(IRootScopeTypeResolveContext context, IRootScope scope)
        {
            if (this.typeResolverResolver.TryResolveScopeTypeResolver(scope, out var scopeTypeResolver) == false)
            {
                throw new NotImplementedException();
            }

            return scopeTypeResolver.ResolveScopeType(context, scope);
        }
    }
}
