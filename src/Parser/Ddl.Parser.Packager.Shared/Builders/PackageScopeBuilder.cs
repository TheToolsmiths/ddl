using TheToolsmiths.Ddl.Models.Package.Content;
using TheToolsmiths.Ddl.Models.Package.Scopes;

namespace TheToolsmiths.Ddl.Parser.Packager.Builders
{
    public class PackageScopeBuilder : PackageScopeContentBuilder
    {
        public PackageScopeBuilder(PackageItemsBuilder itemsBuilder)
            : base(itemsBuilder)
        {
        }

        public PackageScope Build()
        {
            // TODO: Add other scope properties like attributes and conditionals

            var scopeContent = this.BuildScopeContent();

            return new PackageScope(scopeContent);
        }

        protected override PackageScopeContent BuildScopeContent()
        {
            var buildItems = this.BuildItems();
            var buildScopes = this.BuildScopes();

            return new PackageScopeContent(buildItems, buildScopes);
        }
    }
}
