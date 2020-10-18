using TheToolsmiths.Ddl.Models.Compiled.Namespaces.Paths;

namespace TheToolsmiths.Ddl.Parser.Packager.ContentUnits
{
    public class PackageContentUnitNamespace
    {
        public PackageContentUnitNamespace(QualifiedNamespacePath namespacePath, PackageContentUnitScopeContent scopeContent)
        {
            this.NamespacePath = namespacePath;
            this.ScopeContent = scopeContent;
        }

        public QualifiedNamespacePath NamespacePath { get; }

        public PackageContentUnitScopeContent ScopeContent { get; }
    }
}
