using TheToolsmiths.Ddl.Models.Build.Package.Content;

namespace TheToolsmiths.Ddl.Models.Build.Package.Scopes
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
