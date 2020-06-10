using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items;

namespace TheToolsmiths.Ddl.Parser.Models.Structs
{
    public interface IStructItem : IRootItem
    {
        StructItemKind ItemKind { get; }
    }
}
