using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Entries;

namespace TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items
{
    public interface IRootContentItem : IRootContentEntry
    {
        ContentUnitItemType ItemType { get; }
    }
}
