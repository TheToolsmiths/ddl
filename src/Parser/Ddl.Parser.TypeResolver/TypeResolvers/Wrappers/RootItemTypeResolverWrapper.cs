using TheToolsmiths.Ddl.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.TypeResolver.Contexts;
using TheToolsmiths.Ddl.Parser.TypeResolver.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.TypeResolvers.Wrappers
{
    internal class RootItemTypeResolverWrapper<TResolver, TItem> : RootItemTypeResolverWrapper
        where TResolver : IItemTypeResolver<TItem>
        where TItem : class, IRootItem
    {
        private readonly TResolver typeResolver;

        public RootItemTypeResolverWrapper(TResolver typeResolver)
        {
            this.typeResolver = typeResolver;
        }

        public override RootItemTypeResolveResult ResolveItemType(IRootItemTypeResolveContext context, IRootItem item)
        {
            return this.typeResolver.ResolveItemTypes(context, (TItem)item);
        }
    }

    internal abstract class RootItemTypeResolverWrapper
    {
        public abstract RootItemTypeResolveResult ResolveItemType(IRootItemTypeResolveContext context, IRootItem item);
    }
}
