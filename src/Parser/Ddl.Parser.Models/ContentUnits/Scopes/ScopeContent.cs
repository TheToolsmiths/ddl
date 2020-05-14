using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items;

namespace TheToolsmiths.Ddl.Parser.Models.ContentUnits.Scopes
{
    public class ScopeContent
    {
        public ScopeContent(IReadOnlyList<IRootItem> items, IReadOnlyList<IRootScope> scopes)
        {
            this.Items = items;
            this.Scopes = scopes;
        }

        public IReadOnlyList<IRootItem> Items { get; }

        public IReadOnlyList<IRootScope> Scopes { get; }
    }
}
