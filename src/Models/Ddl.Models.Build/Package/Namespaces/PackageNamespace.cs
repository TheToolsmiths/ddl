using TheToolsmiths.Ddl.Models.Build.Package.Content;
using TheToolsmiths.Ddl.Models.Build.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Models.Build.Package.Namespaces
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
