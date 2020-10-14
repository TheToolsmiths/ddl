using TheToolsmiths.Ddl.Models.Compiled.Package.Content;

namespace TheToolsmiths.Ddl.Models.Compiled.Package.Scopes
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
