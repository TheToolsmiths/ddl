using TheToolsmiths.Ddl.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.TypeResolver.Contexts;
using TheToolsmiths.Ddl.Parser.TypeResolver.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver
{
    public interface IRootItemTypeResolver
    {
        RootItemTypeResolveResult ResolveItem(IRootItemTypeResolveContext context, IRootItem item);
    }
}
