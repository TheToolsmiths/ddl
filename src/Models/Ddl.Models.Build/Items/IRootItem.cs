using TheToolsmiths.Ddl.Models.EntryTypes;
using TheToolsmiths.Ddl.Models.Items;

namespace TheToolsmiths.Ddl.Models.Build.Items
{
    public interface IRootItem
    {
        ItemId ItemId { get; }

        ItemType ItemType { get; }
    }
}
