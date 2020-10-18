using TheToolsmiths.Ddl.Models.Compiled.Namespaces.Paths;
using TheToolsmiths.Ddl.Models.Compiled.Package.Content;

namespace TheToolsmiths.Ddl.Models.Compiled.Package.Namespaces
{
    public class PackageNamespace
    {
        public PackageNamespace(QualifiedNamespacePath namespacePath, PackageScopeContent scopeContent)
        {
            this.NamespacePath = namespacePath;
            this.ScopeContent = scopeContent;
        }

        public QualifiedNamespacePath NamespacePath { get; }

        public PackageScopeContent ScopeContent { get; }
    }
}
