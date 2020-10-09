using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Parser.Packager.ContentUnits
{
    public class PackageContentUnit
    {
        public PackageContentUnit(
            ContentUnitId id,
            ContentUnitInfo info,
            RootNamespacePath namespacePath,
            PackageItemsCollection items,
            PackageContentUnitRootContent rootContent)
        {
            this.Id = id;
            this.Info = info;
            this.Items = items;
            this.RootContent = rootContent;
            this.NamespacePath = namespacePath;
        }

        public ContentUnitId Id { get; }

        public ContentUnitInfo Info { get; }

        public PackageItemsCollection Items { get; }

        public PackageContentUnitRootContent RootContent { get; }

        public RootNamespacePath NamespacePath { get; }
    }
}
