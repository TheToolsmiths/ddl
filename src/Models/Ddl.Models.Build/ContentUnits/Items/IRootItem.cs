using TheToolsmiths.Ddl.Models.Build.EntryTypes;

namespace TheToolsmiths.Ddl.Models.Build.ContentUnits.Items
{
    public interface IRootItem
    {
        ItemType ItemType { get; }

        ItemId ItemId { get; }
    }
}
