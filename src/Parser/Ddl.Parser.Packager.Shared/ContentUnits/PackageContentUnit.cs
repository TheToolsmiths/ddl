using TheToolsmiths.Ddl.Models.Build.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Parser.Packager.ContentUnits
{
    public class PackageContentUnit
    {
        public PackageContentUnit(
            ContentUnitId id,
            ContentUnitInfo info,
            RootNamespacePath namespacePath,
            PackageContentUnitItemsCollection items,
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

        public PackageContentUnitItemsCollection Items { get; }

        public PackageContentUnitRootContent RootContent { get; }

        public RootNamespacePath NamespacePath { get; }
    }
}
