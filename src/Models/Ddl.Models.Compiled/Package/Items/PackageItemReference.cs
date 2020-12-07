using TheToolsmiths.Ddl.Models.EntryTypes;
using TheToolsmiths.Ddl.Models.ItemIds;

namespace TheToolsmiths.Ddl.Models.Compiled.Package.Items
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
