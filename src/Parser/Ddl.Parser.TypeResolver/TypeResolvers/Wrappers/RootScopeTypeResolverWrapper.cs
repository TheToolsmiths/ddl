using TheToolsmiths.Ddl.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.TypeResolver.Contexts;
using TheToolsmiths.Ddl.Parser.TypeResolver.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.TypeResolvers.Wrappers
{
    internal class RootScopeTypeResolverWrapper<TResolver, TScope> : RootScopeTypeResolverWrapper
        where TResolver : IScopeTypeResolver<TScope>
        where TScope : class, IRootScope
    {
        private readonly TResolver typeResolver;

        public RootScopeTypeResolverWrapper(TResolver typeResolver)
        {
            this.typeResolver = typeResolver;
        }

        public override RootScopeTypeResolveResult ResolveScopeType(IRootScopeTypeResolveContext context, IRootScope item)
        {
            return this.typeResolver.ResolveScopeTypes(context, (TScope)item);
        }
    }

    internal abstract class RootScopeTypeResolverWrapper
    {
        public abstract RootScopeTypeResolveResult ResolveScopeType(IRootScopeTypeResolveContext context, IRootScope item);
    }
}
