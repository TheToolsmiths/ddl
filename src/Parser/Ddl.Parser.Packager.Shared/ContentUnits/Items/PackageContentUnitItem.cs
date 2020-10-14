using TheToolsmiths.Ddl.Models.Build.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.Build.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Packager.ContentUnits.Items
{
    public class PackageContentUnitItem
    {
        public PackageContentUnitItem(in ItemId itemId, ItemType itemType, IRootItem item)
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
