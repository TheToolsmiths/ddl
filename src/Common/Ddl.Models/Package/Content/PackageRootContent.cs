using TheToolsmiths.Ddl.Models.Package.Namespaces;

namespace TheToolsmiths.Ddl.Models.Package.Content
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
