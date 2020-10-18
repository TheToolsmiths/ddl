using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.Build.Structs.Content
{
    public class Scope : IStructItem
    {
        public Scope(IReadOnlyList<IStructItem> items)
        {
            this.Items = items;
        }

        public IReadOnlyList<IStructItem> Items { get; }

        public StructContentItemKind ItemKind => StructContentItemKind.Scope;
    }
}
