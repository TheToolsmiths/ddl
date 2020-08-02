using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Models.ContentUnits.Items
{
    public interface IRootItem
    {
        ItemType ItemType { get; }

        ItemId ItemId { get; }
    }
}
