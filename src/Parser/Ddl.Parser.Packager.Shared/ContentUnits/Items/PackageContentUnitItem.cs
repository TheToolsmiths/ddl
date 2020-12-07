using TheToolsmiths.Ddl.Models.Compiled.Items;
using TheToolsmiths.Ddl.Models.EntryTypes;
using TheToolsmiths.Ddl.Models.ItemIds;

namespace TheToolsmiths.Ddl.Parser.Packager.ContentUnits.Items
{
    public class PackageContentUnitItem
    {
        public PackageContentUnitItem(in ItemId itemId, ItemType itemType, ICompiledItem item)
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
