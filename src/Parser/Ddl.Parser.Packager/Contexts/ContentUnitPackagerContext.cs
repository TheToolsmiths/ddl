using TheToolsmiths.Ddl.Parser.Packager.ContentUnits.Builders;
using TheToolsmiths.Ddl.Parser.Packager.ContentUnits.Items;

namespace TheToolsmiths.Ddl.Parser.Packager.Contexts
{
    internal class ContentUnitPackagerContext
    {
        private readonly ContentUnitPackageScopeContentBuilder builder;

        private ContentUnitPackagerContext(ContentUnitPackageScopeContentBuilder builder)
        {
            this.builder = builder;
        }

        public static ContentUnitPackagerContext Create(ContentUnitPackageNamespaceBuilder namespaceBuilder)
        {
            return new ContentUnitPackagerContext(namespaceBuilder);
        }

        public ContentUnitPackagerContext CreateScopeContext()
        {
            var scopeBuilder = this.builder.CreateScope();

            return new ContentUnitPackagerContext(scopeBuilder);
        }

        public void AddItem(PackageContentUnitItem packageItem)
        {
            this.builder.AddItem(packageItem);
        }
    }
}
