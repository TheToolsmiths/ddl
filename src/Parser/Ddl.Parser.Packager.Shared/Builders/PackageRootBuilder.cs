using TheToolsmiths.Ddl.Models.Build.Namespaces.Paths;
using TheToolsmiths.Ddl.Models.Compiled.Namespaces.Paths;
using TheToolsmiths.Ddl.Models.Compiled.Package.Content;

namespace TheToolsmiths.Ddl.Parser.Packager.Builders
{
    public class PackageRootBuilder
    {
        private PackageRootBuilder(PackageItemsBuilder itemsBuilder)
        {
            this.ItemsBuilder = itemsBuilder;
            this.RootNamespaceBuilder = new PackageNamespaceBuilder(itemsBuilder, QualifiedNamespacePath.Root);
        }

        public PackageNamespaceBuilder RootNamespaceBuilder { get; }

        public PackageItemsBuilder ItemsBuilder { get; }

        public static PackageRootBuilder CreateRoot(PackageItemsBuilder itemsBuilder)
        {
            return new PackageRootBuilder(itemsBuilder);
        }

        public PackageNamespaceBuilder CreateNamespaceBuilder(RootNamespacePath namespacePath)
        {
            var currentNamespace = this.RootNamespaceBuilder;

            foreach (string pathIdentifier in namespacePath.Identifiers)
            {
                currentNamespace = currentNamespace.GetOrCreateNamespace(pathIdentifier);
            }

            return currentNamespace;
        }

        public PackageRootContent BuildRootContent()
        {
            var rootNamespace = this.RootNamespaceBuilder.Build();

            return new PackageRootContent(rootNamespace);
        }
    }
}
