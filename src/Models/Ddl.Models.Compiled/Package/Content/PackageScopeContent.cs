using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Compiled.Package.Items;
using TheToolsmiths.Ddl.Models.Compiled.Package.Scopes;

namespace TheToolsmiths.Ddl.Models.Compiled.Package.Content
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
