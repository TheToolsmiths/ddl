using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Packager.ContentUnits.Items;

namespace TheToolsmiths.Ddl.Parser.Packager.ContentUnits.Builders
{
    public class ContentUnitPackageItemsBuilder
    {
        public ContentUnitPackageItemsBuilder()
        {
            this.Items = new List<PackageContentUnitItem>();
        }

        public List<PackageContentUnitItem> Items { get; }

        public void AddItem(PackageContentUnitItem item)
        {
            this.Items.Add(item);
        }

        public PackageContentUnitItemsCollection Build()
        {
            return new PackageContentUnitItemsCollection(this.Items);
        }
    }
}
