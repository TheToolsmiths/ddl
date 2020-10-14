using TheToolsmiths.Ddl.Models.Compiled.Package.Namespaces;

namespace TheToolsmiths.Ddl.Models.Compiled.Package.Content
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
