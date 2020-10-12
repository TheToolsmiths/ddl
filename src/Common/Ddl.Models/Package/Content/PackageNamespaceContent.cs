using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Package.Items;
using TheToolsmiths.Ddl.Models.Package.Namespaces;
using TheToolsmiths.Ddl.Models.Package.Scopes;

namespace TheToolsmiths.Ddl.Models.Package.Content
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
