using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.References.TypeReferences;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.ContentUnits
{
    public class ContentUnitIndexedNamespaceBuilder
    {
        private ContentUnitIndexedNamespaceBuilder(NamespacePath namespacePath, string identifier, bool isRoot)
        {
            this.NamespacePath = namespacePath;
            this.Identifier = identifier;
            this.IsRoot = isRoot;
            this.ChildNamespaces = new Dictionary<string, ContentUnitIndexedNamespaceBuilder>();

            this.Items = new Dictionary<string, ContentUnitIndexedPathBuilder>();
        }

        public Dictionary<string, ContentUnitIndexedPathBuilder> Items { get; }

        public NamespacePath NamespacePath { get; }

        public string Identifier { get; }

        public bool IsRoot { get; }

        public Dictionary<string, ContentUnitIndexedNamespaceBuilder> ChildNamespaces { get; }

        public static ContentUnitIndexedNamespaceBuilder CreateRoot()
        {
            return new ContentUnitIndexedNamespaceBuilder(RootNamespacePath.EmptyRoot, string.Empty, true);
        }

        public ContentUnitIndexedNamespace Build()
        {
            var childNamespaces = this.ChildNamespaces.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Build());

            var items = this.Items.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Build());

            return new ContentUnitIndexedNamespace(this.Identifier, this.IsRoot, items, childNamespaces);
        }

        public ContentUnitIndexedNamespaceBuilder TryGetNamespaceBuilder(NamespacePath namespacePath)
        {
            if (namespacePath.IsRooted)
            {
                return this;
            }

            var currentNamespaceBuilder = this;

            foreach (string identifier in namespacePath.Identifiers)
            {
                currentNamespaceBuilder = currentNamespaceBuilder.GetOrCreateChildNamespace(identifier);
            }

            throw new NotImplementedException();
        }

        public void IndexItemType(ItemTypePathReference itemTypeReference)
        {
            var itemsCollection = this.GetItemsCollection(itemTypeReference);

            itemsCollection.IndexItem(itemTypeReference);
        }

        public void IndexSubItemType(SubItemTypePathReference subItemTypeReference)
        {
            var itemsCollection = this.GetItemsCollection(subItemTypeReference);

            itemsCollection.IndexSubItem(subItemTypeReference);
        }

        private ContentUnitIndexedNamespaceBuilder GetOrCreateChildNamespace(string identifier)
        {
            if (this.ChildNamespaces.TryGetValue(identifier, out var childBuilder))
            {
                return childBuilder;
            }

            var namespacePath = NamespacePath.Append(this.NamespacePath, identifier);

            childBuilder = new ContentUnitIndexedNamespaceBuilder(namespacePath, identifier, false);

            this.ChildNamespaces.Add(identifier, childBuilder);

            return childBuilder;
        }

        private ContentUnitIndexedPathBuilder GetItemsCollection(EntityTypeReference typeReference)
        {
            string typeName = typeReference.EntityTypeName.ItemName.Name;

            if (this.Items.TryGetValue(typeName, out var itemsCollection) == false)
            {
                itemsCollection = new ContentUnitIndexedPathBuilder();
                this.Items.Add(typeName, itemsCollection);
            }

            return itemsCollection;
        }
    }
}
