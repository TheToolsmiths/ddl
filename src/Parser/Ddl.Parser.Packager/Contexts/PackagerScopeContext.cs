using TheToolsmiths.Ddl.Parser.Packager.Builders;
using TheToolsmiths.Ddl.Parser.Packager.Items;

namespace TheToolsmiths.Ddl.Parser.Packager.Contexts
{
    internal class PackagerScopeContext
    {
        public PackagerScopeContext(PackageScopeBuilder builder)
        {
            this.Builder = builder;
        }

        public PackageScopeBuilder Builder { get; }

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
