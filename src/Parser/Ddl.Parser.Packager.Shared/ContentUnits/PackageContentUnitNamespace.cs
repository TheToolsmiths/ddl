using TheToolsmiths.Ddl.Models.Build.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Parser.Packager.ContentUnits
{
    public class PackageContentUnitNamespace
    {
        public PackageContentUnitNamespace(RootNamespacePath namespacePath, PackageContentUnitScopeContent scopeContent)
        {
            this.NamespacePath = namespacePath;
            this.ScopeContent = scopeContent;
        }

        public RootNamespacePath NamespacePath { get; }

        public PackageContentUnitScopeContent ScopeContent { get; }
    }
}