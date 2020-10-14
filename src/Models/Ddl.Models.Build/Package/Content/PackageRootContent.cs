using TheToolsmiths.Ddl.Models.Build.Package.Namespaces;

namespace TheToolsmiths.Ddl.Models.Build.Package.Content
{
    public class PackageRootContent
    {
        public PackageRootContent(PackageNamespace rootNamespace)
        {
            this.RootNamespace = rootNamespace;
        }

        public PackageNamespace RootNamespace { get; }
    }
}
