using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.Package.Content;
using TheToolsmiths.Ddl.Models.Package.Items;
using TheToolsmiths.Ddl.Models.Package.Scopes;

namespace TheToolsmiths.Ddl.Parser.Packager.Builders
{
    public abstract class PackageScopeContentBuilder
    {
        private readonly List<PackageItemReference> items;
        protected readonly PackageItemsBuilder itemsBuilder;
        protected readonly List<PackageScopeBuilder> scopes;

        protected PackageScopeContentBuilder(PackageItemsBuilder itemsBuilder)
        {
            this.itemsBuilder = itemsBuilder;

            this.items = new List<PackageItemReference>();
            this.scopes = new List<PackageScopeBuilder>();
        }

        public void AddItem(PackageItemReference packageItem)
        {
            this.items.Add(packageItem);
        }

        public PackageScopeBuilder CreateScope()
        {
            var scopeBuilder = new PackageScopeBuilder(this.itemsBuilder);

            this.scopes.Add(scopeBuilder);

            return scopeBuilder;
        }

        protected abstract PackageScopeContent BuildScopeContent();

        protected IReadOnlyList<PackageItemReference> BuildItems()
        {
            var items = new List<PackageItemReference>();

            foreach (var packageItem in this.items)
            {
                var itemReference = new PackageItemReference(packageItem.ItemId, packageItem.ItemType);
                items.Add(itemReference);
            }

            return this.items;
        }

        protected IReadOnlyList<PackageScope> BuildScopes()
        {
            return this.scopes.Select(s => s.Build()).ToList();
        }
    }
}
