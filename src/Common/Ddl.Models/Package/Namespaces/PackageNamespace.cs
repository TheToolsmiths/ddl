using TheToolsmiths.Ddl.Models.Package.Content;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Models.Package.Namespaces
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
