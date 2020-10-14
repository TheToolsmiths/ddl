using TheToolsmiths.Ddl.Models.Build.Package.Content;
using TheToolsmiths.Ddl.Models.Build.Package.Items;

namespace TheToolsmiths.Ddl.Models.Build.Package
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
