using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Packager.Items;
using TheToolsmiths.Ddl.Parser.Packager.Namespaces;
using TheToolsmiths.Ddl.Parser.Packager.Scopes;

namespace TheToolsmiths.Ddl.Parser.Packager.Content
{
    public class PackageNamespaceContent : PackageScopeContent
    {
        public PackageNamespaceContent(
            IReadOnlyList<PackageItemReference> items,
            IReadOnlyList<PackageNamespace> namespaces,
            IReadOnlyList<PackageScope> scopes)
            : base(items, scopes)
        {
            this.Namespaces = namespaces;
        }

        public IReadOnlyList<PackageNamespace> Namespaces { get; }
    }
}
