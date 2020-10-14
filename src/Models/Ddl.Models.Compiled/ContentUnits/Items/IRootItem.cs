using TheToolsmiths.Ddl.Models.Compiled.EntryTypes;

namespace TheToolsmiths.Ddl.Models.Compiled.ContentUnits.Items
{
    public interface IRootItem
    {
        ItemType ItemType { get; }

        ItemId ItemId { get; }
    }
}
