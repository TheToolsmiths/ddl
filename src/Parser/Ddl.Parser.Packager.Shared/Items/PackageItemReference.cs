using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Packager.Items
{
    public class PackageItemReference
    {
        public PackageItemReference(in ItemId itemId, ItemType itemType)
        {
            this.ItemId = itemId;
            this.ItemType = itemType;
        }

        public ItemId ItemId { get; }

        public ItemType ItemType { get; }
    }
}
