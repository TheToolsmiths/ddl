using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;
using TheToolsmiths.Ddl.Parser.Packager.Content;
using TheToolsmiths.Ddl.Parser.Packager.Scopes;

namespace TheToolsmiths.Ddl.Parser.Packager.Namespaces
{
    public class PackageNamespace
    {
        public PackageNamespace(RootNamespacePath namespacePath, PackageScopeContent scopeContent)
        {
            this.NamespacePath = namespacePath;
            this.ScopeContent = scopeContent;
        }

        public RootNamespacePath NamespacePath { get; }

        public PackageScopeContent ScopeContent { get; }
    }
}
