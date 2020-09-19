using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.Contexts
{
    public interface IRootItemTypeResolveContext : IRootEntryTypeResolveContext
    {
        IRootItemTypeResolveContext AddTypeNameInfoToContext(TypedItemName typeName);
    }
}
