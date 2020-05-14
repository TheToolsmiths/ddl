using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Entries;

namespace TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items
{
    public interface IRootItem : IRootEntry
    {
        ContentUnitItemType ItemType { get; }
    }
}
