using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.TypeReferences
{
    public class TypeReferenceIndexedNamespaceBuilder
    {
        public TypeReferenceIndexedNamespaceBuilder()
        {
            this.Identifier = string.Empty;
            this.Items = new TypeReferenceIndexedItemsBuilder();
            this.ChildNamespaces = new Dictionary<string, TypeReferenceIndexedNamespaceBuilder>();
        }

        public string Identifier { get; set; }

        public Dictionary<string, TypeReferenceIndexedNamespaceBuilder> ChildNamespaces { get; }

        public TypeReferenceIndexedItemsBuilder Items { get; }

        public TypeReferenceIndexedNamespaceBuilder GetChildNamespace(string identifier)
        {
            if (this.ChildNamespaces.TryGetValue(identifier, out var childNamespaceBuilder) == false)
            {
                childNamespaceBuilder = new TypeReferenceIndexedNamespaceBuilder();

                this.ChildNamespaces.Add(identifier, childNamespaceBuilder);
            }

            return childNamespaceBuilder;
        }

        public TypeReferenceIndexedNamespace Build()
        {
            return this.BuildInternal(null, null);
        }

        private TypeReferenceIndexedNamespace BuildInternal(
            TypeReferenceIndexedNamespace? rootNamespace,
            TypeReferenceIndexedNamespace? parentNamespace)
        {
            string identifier = this.Identifier ?? throw new InvalidOperationException($"{nameof(this.Identifier)} is (null) or empty");

            var items = this.Items.Build();
            var childNamespaces = new Dictionary<string, TypeReferenceIndexedNamespace>();

            RootNamespacePath namespacePath;
            if (parentNamespace == null)
            {
                namespacePath = RootNamespacePath.EmptyRoot;
            }
            else
            {
                var parentNamespacePath = parentNamespace.NamespacePath;

                namespacePath = RootNamespacePath.Create(parentNamespacePath, identifier);
            }

            var indexedNamespace = new TypeReferenceIndexedNamespace(identifier, namespacePath, items, parentNamespace, rootNamespace, childNamespaces);

            foreach (var (key, childBuilder) in this.ChildNamespaces)
            {
                var childNamespace = childBuilder.BuildInternal(rootNamespace ?? indexedNamespace, indexedNamespace);

                childNamespaces.Add(key, childNamespace);
            }

            return indexedNamespace;
        }
    }
}
