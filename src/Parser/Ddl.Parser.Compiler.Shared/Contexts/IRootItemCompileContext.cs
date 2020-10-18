using TheToolsmiths.Ddl.Models.Types.Items;

namespace TheToolsmiths.Ddl.Parser.Compiler.Contexts
{
    public interface IRootItemCompileContext : IRootEntryTypeResolveContext
    {
        IRootItemCompileContext AddTypeNameInfoToContext(ItemTypeName typeName);
    }
}
