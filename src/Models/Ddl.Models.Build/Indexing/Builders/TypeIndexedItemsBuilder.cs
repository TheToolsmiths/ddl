using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.Build.Types.References;

namespace TheToolsmiths.Ddl.Models.Build.Indexing.Builders
{
    public class TypeIndexedItemsBuilder
    {
        public TypeIndexedItemsBuilder()
        {
            this.MappedItems = new Dictionary<string, TypeIndexedPathBuilder>();
        }

        public Dictionary<string, TypeIndexedPathBuilder> MappedItems { get; }

        public void AddItemReference(string itemName, ItemTypePathReference pathReference)
        {
            if (this.MappedItems.TryGetValue(itemName, out var pathReferences) == false)
            {
                pathReferences = new TypeIndexedPathBuilder();

                this.MappedItems.Add(itemName, pathReferences);
            }

            pathReferences.AddItem(pathReference);
        }

        public void AddSubItemReference(string itemName, string subItemName, SubItemTypePathReference pathReference)
        {
            if (this.MappedItems.TryGetValue(itemName, out var pathReferences) == false)
            {
                pathReferences = new TypeIndexedPathBuilder();

                this.MappedItems.Add(itemName, pathReferences);
            }

            pathReferences.AddSubItem(subItemName, pathReference);
        }

        public TypeIndexedItems Build()
        {
            var items = this.MappedItems.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Build());

            return new TypeIndexedItems(items);
        }
    }
}
