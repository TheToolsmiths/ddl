using TheToolsmiths.Ddl.Models.Package.Content;

namespace TheToolsmiths.Ddl.Models.Package.Scopes
{
    public class PackageScope
    {
        public PackageScope(PackageScopeContent scopeContent)
        {
            this.ScopeContent = scopeContent;
        }

        public PackageScopeContent ScopeContent { get; }
    }
}
