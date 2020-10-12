using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Package.Items;

namespace TheToolsmiths.Ddl.Parser.Packager.Builders
{
    public class PackageItemsBuilder
    {
        public PackageItemsBuilder()
        {
            this.Items = new List<PackageItem>();
        }

        public List<PackageItem> Items { get; }

        public void AddItem(PackageItem item)
        {
            this.Items.Add(item);
        }

        public PackageItemsCollection Build()
        {
            return new PackageItemsCollection(this.Items);
        }
    }
}
