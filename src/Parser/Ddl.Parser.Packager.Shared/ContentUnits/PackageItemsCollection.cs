using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Packager.Items;

namespace TheToolsmiths.Ddl.Parser.Packager.ContentUnits
{
    public class PackageItemsCollection
    {
        public PackageItemsCollection(IReadOnlyList<PackageItem> items, IReadOnlyList<PackageTypedItem> typedItems)
        {
            this.Items = items;
            this.TypedItems = typedItems;
        }

        public IReadOnlyList<PackageItem> Items { get; }

        public IReadOnlyList<PackageTypedItem> TypedItems { get; }
    }
}
