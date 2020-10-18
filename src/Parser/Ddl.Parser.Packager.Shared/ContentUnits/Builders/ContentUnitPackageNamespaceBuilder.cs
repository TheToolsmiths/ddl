using TheToolsmiths.Ddl.Models.Compiled.Namespaces.Paths;

namespace TheToolsmiths.Ddl.Parser.Packager.ContentUnits.Builders
{
    public class ContentUnitPackageNamespaceBuilder : ContentUnitPackageScopeContentBuilder
    {
        internal ContentUnitPackageNamespaceBuilder(
            ContentUnitPackageItemsBuilder itemsBuilder,
            QualifiedNamespacePath namespacePath)
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
