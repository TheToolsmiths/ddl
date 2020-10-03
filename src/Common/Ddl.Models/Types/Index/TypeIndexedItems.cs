using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.Types.Index
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
