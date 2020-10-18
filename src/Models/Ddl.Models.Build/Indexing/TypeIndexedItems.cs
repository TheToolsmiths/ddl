using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.Build.Indexing
{
    public class TypeIndexedItems
    {
        public TypeIndexedItems(IReadOnlyDictionary<string, TypeIndexedPath> items)
        {
            this.Items = items;
        }

        public IReadOnlyDictionary<string, TypeIndexedPath> Items { get; }
    }
}
