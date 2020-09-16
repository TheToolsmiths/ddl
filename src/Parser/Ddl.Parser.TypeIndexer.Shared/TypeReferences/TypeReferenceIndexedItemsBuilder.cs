using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.References.TypeReferences;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.TypeReferences
{
    public class TypeReferenceIndexedItemsBuilder
    {
        public TypeReferenceIndexedItemsBuilder()
        {
            this.MappedItems = new Dictionary<string, TypeReferenceIndexedPathBuilder>();
        }

        public Dictionary<string, TypeReferenceIndexedPathBuilder> MappedItems { get; }

        public void AddItemReference(string itemName, ItemTypePathReference pathReference)
        {
            if (this.MappedItems.TryGetValue(itemName, out var pathReferences) == false)
            {
                pathReferences = new TypeReferenceIndexedPathBuilder();

                this.MappedItems.Add(itemName, pathReferences);
            }

            pathReferences.AddItem(pathReference);
        }

        public void AddSubItemReference(string itemName, string subItemName, SubItemTypePathReference pathReference)
        {
            if (this.MappedItems.TryGetValue(itemName, out var pathReferences) == false)
            {
                pathReferences = new TypeReferenceIndexedPathBuilder();

                this.MappedItems.Add(itemName, pathReferences);
            }

            pathReferences.AddSubItem(subItemName, pathReference);
        }

        public TypeReferenceIndexedItems Build()
        {
            var items = this.MappedItems.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Build());

            return new TypeReferenceIndexedItems(items);
        }
    }
}