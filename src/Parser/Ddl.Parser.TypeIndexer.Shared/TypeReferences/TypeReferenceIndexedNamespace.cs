using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.TypeReferences
{
    public class TypeReferenceIndexedNamespace
    {
        public TypeReferenceIndexedNamespace(
            string identifier,
            RootNamespacePath namespacePath,
            TypeReferenceIndexedItems items,
            TypeReferenceIndexedNamespace? parentNamespace,
            TypeReferenceIndexedNamespace? rootNamespace,
            IReadOnlyDictionary<string, TypeReferenceIndexedNamespace> childNamespaces)
        {
            this.ParentNamespace = parentNamespace;
            this.Identifier = identifier;
            this.Items = items;
            this.ChildNamespaces = childNamespaces;
            this.NamespacePath = namespacePath;
            this.RootNamespace = rootNamespace ?? this;
        }

        public TypeReferenceIndexedNamespace? ParentNamespace { get; }

        public TypeReferenceIndexedNamespace RootNamespace { get; }

        public string Identifier { get; }

        public bool HasParent => this.ParentNamespace != null;

        public RootNamespacePath NamespacePath { get; }

        public TypeReferenceIndexedItems Items { get; }

        public IReadOnlyDictionary<string, TypeReferenceIndexedNamespace> ChildNamespaces { get; }
    }
}
