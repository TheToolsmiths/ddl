using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.TypeReferences
{
    public class TypeReferenceIndexedNamespace
    {
        public TypeReferenceIndexedNamespace(
            TypeReferenceIndexedNamespace? parentNamespace,
            string identifier,
            TypeReferenceIndexedItems items,
            IReadOnlyDictionary<string, TypeReferenceIndexedNamespace> childNamespaces)
        {
            this.ParentNamespace = parentNamespace;
            this.Identifier = identifier;
            this.Items = items;
            this.ChildNamespaces = childNamespaces;
        }

        public TypeReferenceIndexedNamespace? ParentNamespace { get; }

        public string Identifier { get; }

        public bool HasParent => this.ParentNamespace != null;

        public TypeReferenceIndexedItems Items { get; }

        public IReadOnlyDictionary<string, TypeReferenceIndexedNamespace> ChildNamespaces { get; }
    }
}
