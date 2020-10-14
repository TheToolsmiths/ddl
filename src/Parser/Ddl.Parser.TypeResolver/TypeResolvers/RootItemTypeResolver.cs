using System;
using TheToolsmiths.Ddl.Models.Build.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.TypeResolver.Contexts;
using TheToolsmiths.Ddl.Parser.TypeResolver.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.TypeResolvers
{
    internal class RootItemTypeResolver : IRootItemTypeResolver
    {
        private readonly RootTypeResolverResolver typeResolverResolver;

        public RootItemTypeResolver(RootTypeResolverResolver typeResolverResolver)
        {
            this.typeResolverResolver = typeResolverResolver;
        }

        public RootItemTypeResolveResult ResolveItem(IRootItemTypeResolveContext context, IRootItem item)
        {
            if (this.typeResolverResolver.TryResolveItemTypeResolver(item, out var itemTypeResolver) == false)
            {
                throw new NotImplementedException();
            }

            return itemTypeResolver.ResolveItemType(context, item);
        }
    }
}
