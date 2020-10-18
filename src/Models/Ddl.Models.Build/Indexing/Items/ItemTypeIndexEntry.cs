using TheToolsmiths.Ddl.Models.Build.Items.References;
using TheToolsmiths.Ddl.Models.Types.Items;

namespace TheToolsmiths.Ddl.Models.Build.Indexing.Items
{
    public class ItemTypeIndexEntry
    {
        public ItemTypeIndexEntry(ItemTypeName typeName, ItemReference itemReference)
        {
            this.TypeName = typeName;
            this.ItemReference = itemReference;
        }

        public ItemTypeName TypeName { get; }

        public ItemReference ItemReference { get; }
    }
}
