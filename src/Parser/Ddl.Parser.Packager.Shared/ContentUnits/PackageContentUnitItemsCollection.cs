using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Packager.ContentUnits.Items;

namespace TheToolsmiths.Ddl.Parser.Packager.ContentUnits
{
    public class PackageContentUnitItemsCollection
    {
        public PackageContentUnitItemsCollection(IReadOnlyList<PackageContentUnitItem> items)
        {
            this.Items = items;
        }

        public IReadOnlyList<PackageContentUnitItem> Items { get; }
    }
}
