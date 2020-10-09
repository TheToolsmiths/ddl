using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Packager.Items;
using TheToolsmiths.Ddl.Parser.Packager.Scopes;

namespace TheToolsmiths.Ddl.Parser.Packager.Content
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
