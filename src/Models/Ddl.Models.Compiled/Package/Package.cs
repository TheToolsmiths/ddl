using TheToolsmiths.Ddl.Models.Compiled.Package.Content;
using TheToolsmiths.Ddl.Models.Compiled.Package.Items;

namespace TheToolsmiths.Ddl.Models.Compiled.Package
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
