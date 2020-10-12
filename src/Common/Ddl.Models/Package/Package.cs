using TheToolsmiths.Ddl.Models.Package.Content;
using TheToolsmiths.Ddl.Models.Package.Items;

namespace TheToolsmiths.Ddl.Models.Package
{
    public class Package
    {
        public Package(PackageItemsCollection items, PackageRootContent rootContent)
        {
            this.Items = items;
            this.RootContent = rootContent;
        }

        public PackageItemsCollection Items { get; }

        public PackageRootContent RootContent { get; }

    }
}
