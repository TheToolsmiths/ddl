using TheToolsmiths.Ddl.Models.Build.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Parser.Packager.ContentUnits.Builders
{
    public class ContentUnitPackageScopeBuilder : ContentUnitPackageScopeContentBuilder
    {
        public ContentUnitPackageScopeBuilder(
            ContentUnitPackageItemsBuilder itemsBuilder,
            RootNamespacePath namespacePath)
            : base(itemsBuilder, namespacePath)
        {
        }

        public PackageContentUnitScope Build()
        {
            // TODO: Add other scope properties like attributes and conditionals

            var scopeContent = base.BuildScopeContent();

            return new PackageContentUnitScope(scopeContent);
        }
    }
}
