using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.Compiled.Package.Items
{
    public class PackageItemsCollection
    {
        public PackageItemsCollection(IReadOnlyList<PackageItem> items)
        {
            this.Items = items;
        }

        public IReadOnlyList<PackageItem> Items { get; }
    }
}
