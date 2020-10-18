using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.Build.Structs.Content
{
    public class StructContent
    {
        public StructContent(IReadOnlyList<IStructItem> items)
        {
            this.Items = items;
        }

        public IReadOnlyList<IStructItem> Items { get; }
    }
}
