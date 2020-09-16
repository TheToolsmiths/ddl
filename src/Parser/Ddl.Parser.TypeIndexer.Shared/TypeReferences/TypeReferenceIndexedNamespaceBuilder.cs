using System;
using System.Collections.Generic;

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
            return this.BuildInternal();
        }

        private TypeReferenceIndexedNamespace BuildInternal(TypeReferenceIndexedNamespace? parentNamespace = null)
        {
            string identifier = this.Identifier ?? throw new InvalidOperationException($"{nameof(this.Identifier)} is (null) or empty");

            var items = this.Items.Build();
            var childNamespaces = new Dictionary<string, TypeReferenceIndexedNamespace>();

            var indexedNamespace = new TypeReferenceIndexedNamespace(parentNamespace, identifier, items, childNamespaces);

            foreach (var (key, childBuilder) in this.ChildNamespaces)
            {
                var childNamespace = childBuilder.BuildInternal(indexedNamespace);

                childNamespaces.Add(key, childNamespace);
            }

            return indexedNamespace;
        }
    }
}
