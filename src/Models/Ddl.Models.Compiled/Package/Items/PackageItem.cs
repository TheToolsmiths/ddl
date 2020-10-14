using TheToolsmiths.Ddl.Models.Compiled.ContentUnits;
using TheToolsmiths.Ddl.Models.Compiled.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.Compiled.EntryTypes;

namespace TheToolsmiths.Ddl.Models.Compiled.Package.Items
{
    public class PackageItem
    {
        public PackageItem(in ItemId itemId, ItemType itemType, IRootItem item)
        {
            this.ItemId = itemId;
            this.ItemType = itemType;
            this.Item = item;
        }

        public ItemId ItemId { get; }

        public ItemType ItemType { get; }

        public IRootItem Item { get; }
    }
}
