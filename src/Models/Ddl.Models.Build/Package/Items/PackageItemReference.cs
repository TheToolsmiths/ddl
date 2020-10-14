using TheToolsmiths.Ddl.Models.Build.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.EntryTypes;

namespace TheToolsmiths.Ddl.Models.Build.Package.Items
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
