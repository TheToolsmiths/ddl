using TheToolsmiths.Ddl.Models.Build.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.TypeResolver.Contexts;
using TheToolsmiths.Ddl.Parser.TypeResolver.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.Common
{
    public class ItemPassthroughTypeResolver : IItemTypeResolver<IRootItem>
    {
        public RootItemTypeResolveResult ResolveItemTypes(IRootItemTypeResolveContext itemContext, IRootItem item)
        {
            return new RootItemTypeResolveSuccess(item);
        }
    }
}
