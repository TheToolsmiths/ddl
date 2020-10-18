using TheToolsmiths.Ddl.Models.Compiled.Namespaces.Paths;
using TheToolsmiths.Ddl.Models.Compiled.Package.Items;
using TheToolsmiths.Ddl.Parser.Packager.Builders;

namespace TheToolsmiths.Ddl.Parser.Packager.Contexts
{
    internal class PackagerNamespaceContext
    {
        private PackagerNamespaceContext(PackageNamespaceBuilder builder)
        {
            this.Builder = builder;
        }

        public PackageNamespaceBuilder Builder { get; }

        public static PackagerNamespaceContext Create(PackageRootBuilder rootBuilder)
        {
            return new PackagerNamespaceContext(rootBuilder.RootNamespaceBuilder);
        }

        public PackagerNamespaceContext CreateNamespaceContext(QualifiedNamespacePath namespacePath)
        {
            var namespaceScope = this.Builder.CreateNamespaceScope(namespacePath);

            return new PackagerNamespaceContext(namespaceScope);
        }

        public PackagerScopeContext CreateScopeContext()
        {
            var scopeBuilder = this.Builder.CreateScope();

            return new PackagerScopeContext(scopeBuilder);
        }

        public void AddItem(PackageItemReference packageItem)
        {
            this.Builder.AddItem(packageItem);
        }
    }
}
