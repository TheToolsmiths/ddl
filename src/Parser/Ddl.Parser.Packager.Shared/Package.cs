using TheToolsmiths.Ddl.Parser.Packager.Content;
using TheToolsmiths.Ddl.Parser.Packager.ContentUnits;

namespace TheToolsmiths.Ddl.Parser.Packager
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
