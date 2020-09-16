using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.ContentUnits
{
    public class ContentUnitIndexedNamespace
    {
        public ContentUnitIndexedNamespace(
            string identifier,
            in bool isRoot,
            IReadOnlyDictionary<string, ContentUnitIndexedPath> items,
            IReadOnlyDictionary<string, ContentUnitIndexedNamespace> childNamespaces)
        {
            this.Identifier = identifier;
            this.IsRoot = isRoot;
            this.Items = items;
            this.ChildNamespaces = childNamespaces;
        }

        public string Identifier { get; }

        public bool IsRoot { get; }

        public IReadOnlyDictionary<string, ContentUnitIndexedPath> Items { get; }

        public IReadOnlyDictionary<string, ContentUnitIndexedNamespace> ChildNamespaces { get; }
    }
}
