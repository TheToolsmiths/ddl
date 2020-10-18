using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.Types.References;

namespace TheToolsmiths.Ddl.Models.Build.Indexing
{
    public class TypeIndexedPath
    {
        public TypeIndexedPath(
            IReadOnlyList<ItemTypePathReference> items,
            IReadOnlyDictionary<string, IReadOnlyList<SubItemTypePathReference>> subItems)
        {
            this.Items = items;
            this.SubItems = subItems;
        }

        public IReadOnlyList<ItemTypePathReference> Items { get; }

        public IReadOnlyDictionary<string, IReadOnlyList<SubItemTypePathReference>> SubItems { get; }
    }
}
