using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;
using TheToolsmiths.Ddl.Parser.Packager.Content;

namespace TheToolsmiths.Ddl.Parser.Packager.ContentUnits.Builders
{
    public class ContentUnitPackageRootBuilder
    {
        private readonly ContentUnitPackageItemsBuilder itemsBuilder;
        private readonly ContentUnitPackageNamespaceBuilder rootNamespaceBuilder;

        private ContentUnitPackageRootBuilder(ContentUnitPackageItemsBuilder itemsBuilder)
        {
            this.itemsBuilder = itemsBuilder;
            this.rootNamespaceBuilder = new ContentUnitPackageNamespaceBuilder(itemsBuilder, RootNamespacePath.EmptyRoot);
        }

        public static ContentUnitPackageRootBuilder CreateRoot()
        {
            var itemsBuilder = new ContentUnitPackageItemsBuilder();

            return new ContentUnitPackageRootBuilder(itemsBuilder);
        }

        public ContentUnitPackageNamespaceBuilder GetNamespaceBuilder(RootNamespacePath namespacePath)
        {
            var currentNamespaceBuilder = this.rootNamespaceBuilder;

            if (namespacePath.IsEmpty)
            {
                return currentNamespaceBuilder;
            }

            foreach (string identifier in namespacePath.Identifiers)
            {
                currentNamespaceBuilder = currentNamespaceBuilder.GetNamespace(identifier);
            }

            return currentNamespaceBuilder;
        }

        public PackageItemsCollection BuildItemsCollection()
        {
            return this.itemsBuilder.Build();
        }

        public PackageContentUnitRootContent BuildRootContent()
        {
            var rootNamespace = this.rootNamespaceBuilder.Build();

            return new PackageContentUnitRootContent(rootNamespace);
        }
    }
}
