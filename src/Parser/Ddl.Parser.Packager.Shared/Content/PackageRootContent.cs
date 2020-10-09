using TheToolsmiths.Ddl.Parser.Packager.Namespaces;

namespace TheToolsmiths.Ddl.Parser.Packager.Content
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
