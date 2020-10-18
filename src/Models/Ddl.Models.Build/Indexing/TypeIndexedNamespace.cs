using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.Namespaces.Paths;

namespace TheToolsmiths.Ddl.Models.Build.Indexing
{
    public class TypeIndexedNamespace
    {
        public TypeIndexedNamespace(
            string identifier,
            RootNamespacePath namespacePath,
            TypeIndexedItems items,
            TypeIndexedNamespace? parentNamespace,
            TypeIndexedNamespace? rootNamespace,
            IReadOnlyDictionary<string, TypeIndexedNamespace> childNamespaces)
        {
            this.ParentNamespace = parentNamespace;
            this.Identifier = identifier;
            this.Items = items;
            this.ChildNamespaces = childNamespaces;
            this.NamespacePath = namespacePath;
            this.RootNamespace = rootNamespace ?? this;
        }

        public TypeIndexedNamespace? ParentNamespace { get; }

        public TypeIndexedNamespace RootNamespace { get; }

        public string Identifier { get; }

        public bool HasParent => this.ParentNamespace != null;

        public RootNamespacePath NamespacePath { get; }

        public TypeIndexedItems Items { get; }

        public IReadOnlyDictionary<string, TypeIndexedNamespace> ChildNamespaces { get; }
    }
}
