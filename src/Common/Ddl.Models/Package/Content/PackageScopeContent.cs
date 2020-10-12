using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Package.Items;
using TheToolsmiths.Ddl.Models.Package.Scopes;

namespace TheToolsmiths.Ddl.Models.Package.Content
{
    public class PackageScopeContent
    {
        public PackageScopeContent(IReadOnlyList<PackageItemReference> items, IReadOnlyList<PackageScope> scopes)
        {
            this.Items = items;
            this.Scopes = scopes;
        }

        public IReadOnlyList<PackageItemReference> Items { get; }

        public IReadOnlyList<PackageScope> Scopes { get; }
    }
}
