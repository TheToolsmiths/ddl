using TheToolsmiths.Ddl.Models.Compiled.Package.Content;
using TheToolsmiths.Ddl.Models.Compiled.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Models.Compiled.Package.Namespaces
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
