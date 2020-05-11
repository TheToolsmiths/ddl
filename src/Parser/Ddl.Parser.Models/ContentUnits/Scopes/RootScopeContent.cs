using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Entries;

namespace TheToolsmiths.Ddl.Parser.Models.ContentUnits.Scopes
{
    public class RootScopeContent
    {
        public RootScopeContent(IReadOnlyList<IRootContentEntry> entries)
        {
            this.Entries = entries;
        }

        public IReadOnlyList<IRootContentEntry> Entries { get; }
    }
}
