using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Compiled.Package.Items;

namespace TheToolsmiths.Ddl.Parser.Packager.ContentUnits
{
    public class PackageContentUnitScopeContent
    {
        public PackageContentUnitScopeContent(IReadOnlyList<PackageItemReference> items, IReadOnlyList<PackageContentUnitNamespace> namespaces, IReadOnlyList<PackageContentUnitScope> scopes)
        {
            this.Items = items;
            this.Namespaces = namespaces;
            this.Scopes = scopes;
        }

        public IReadOnlyList<PackageItemReference> Items { get; }

        public IReadOnlyList<PackageContentUnitNamespace> Namespaces { get; }

        public IReadOnlyList<PackageContentUnitScope> Scopes { get; }
    }
}
