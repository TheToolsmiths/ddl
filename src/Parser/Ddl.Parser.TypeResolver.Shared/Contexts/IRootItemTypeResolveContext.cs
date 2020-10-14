using TheToolsmiths.Ddl.Models.Build.Types.Names;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.Contexts
{
    public interface IRootItemTypeResolveContext : IRootEntryTypeResolveContext
    {
        IRootItemTypeResolveContext AddTypeNameInfoToContext(TypedItemName typeName);
    }
}
