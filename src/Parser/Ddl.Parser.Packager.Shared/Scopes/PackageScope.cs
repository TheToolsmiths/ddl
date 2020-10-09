using TheToolsmiths.Ddl.Parser.Packager.Content;

namespace TheToolsmiths.Ddl.Parser.Packager.Scopes
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
