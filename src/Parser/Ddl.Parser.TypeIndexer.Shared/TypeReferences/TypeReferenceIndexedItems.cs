using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.TypeReferences
{
    public class TypeReferenceIndexedItems
    {
        public TypeReferenceIndexedItems(IReadOnlyDictionary<string, TypeReferenceIndexedPath> items)
        {
            this.Items = items;
        }

        public IReadOnlyDictionary<string, TypeReferenceIndexedPath> Items { get; }
    }
}