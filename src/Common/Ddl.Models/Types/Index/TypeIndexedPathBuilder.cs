using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.References.TypeReferences;

namespace TheToolsmiths.Ddl.Models.Types.Index
{
    public class TypeIndexedPathBuilder
    {
        public TypeIndexedPathBuilder()
        {
            this.MappedItems = new List<ItemTypePathReference>();
            this.MappedSubItems = new Dictionary<string, List<SubItemTypePathReference>>();
        }

        public List<ItemTypePathReference> MappedItems { get; }

        public Dictionary<string, List<SubItemTypePathReference>> MappedSubItems { get; }

        public void AddItem(ItemTypePathReference pathReference)
        {
            this.MappedItems.Add(pathReference);
        }

        public void AddSubItem(string subItemName, SubItemTypePathReference pathReference)
        {
            if (this.MappedSubItems.TryGetValue(subItemName, out var references) == false)
            {
                references = new List<SubItemTypePathReference>();

                this.MappedSubItems.Add(subItemName, references);
            }

            references.Add(pathReference);
        }

        public TypeIndexedPath Build()
        {
            var items = this.MappedItems;
            var subItems = this.MappedSubItems.ToDictionary(kvp => kvp.Key, kvp => (IReadOnlyList<SubItemTypePathReference>)kvp.Value);

            return new TypeIndexedPath(items, subItems);
        }
    }
}
