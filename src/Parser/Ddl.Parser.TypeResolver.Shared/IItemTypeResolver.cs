using TheToolsmiths.Ddl.Models.Build.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.TypeResolver.Contexts;
using TheToolsmiths.Ddl.Parser.TypeResolver.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver
{

    public interface IItemTypeResolver<TItem> : IItemTypeResolver
        where TItem : class, IRootItem
    {
        public RootItemTypeResolveResult ResolveItemTypes(IRootItemTypeResolveContext itemContext, TItem item);
    }

    public interface IItemTypeResolver
    {
    }
}
