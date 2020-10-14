using TheToolsmiths.Ddl.Models.Build.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Parser.Packager.ContentUnits.Builders
{
    public class ContentUnitPackageNamespaceBuilder : ContentUnitPackageScopeContentBuilder
    {
        internal ContentUnitPackageNamespaceBuilder(
            ContentUnitPackageItemsBuilder itemsBuilder,
            RootNamespacePath namespacePath)
            : base(itemsBuilder, namespacePath)
        {
        }

        public PackageContentUnitNamespace Build()
        {
            var scopeContent = base.BuildScopeContent();

            return new PackageContentUnitNamespace(this.NamespacePath, scopeContent);
        }
    }
}
