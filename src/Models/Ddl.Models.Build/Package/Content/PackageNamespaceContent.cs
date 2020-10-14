using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.Package.Items;
using TheToolsmiths.Ddl.Models.Build.Package.Namespaces;
using TheToolsmiths.Ddl.Models.Build.Package.Scopes;

namespace TheToolsmiths.Ddl.Models.Build.Package.Content
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
