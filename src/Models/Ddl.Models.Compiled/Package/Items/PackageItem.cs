using TheToolsmiths.Ddl.Models.Compiled.Items;
using TheToolsmiths.Ddl.Models.EntryTypes;
using TheToolsmiths.Ddl.Models.Items;

namespace TheToolsmiths.Ddl.Models.Compiled.Package.Items
{
    public class PackageItem
    {
        public PackageItem(in ItemId itemId, ItemType itemType, ICompiledItem item)
        {
            this.ItemId = itemId;
            this.ItemType = itemType;
            this.Item = item;
        }

        public ItemId ItemId { get; }

        public ItemType ItemType { get; }

        public ICompiledItem Item { get; }
    }
}
