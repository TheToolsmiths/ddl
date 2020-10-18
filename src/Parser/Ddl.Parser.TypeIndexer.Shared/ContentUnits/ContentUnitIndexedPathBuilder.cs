using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.Build.Types.References;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.ContentUnits
{
    public class ContentUnitIndexedPathBuilder
    {
        public ContentUnitIndexedPathBuilder()
        {
            this.Items = new List<ItemTypePathReference>();

            this.SubItems = new Dictionary<string, List<SubItemTypePathReference>>();
        }

        public Dictionary<string, List<SubItemTypePathReference>> SubItems { get; }

        public List<ItemTypePathReference> Items { get; }

        public ContentUnitIndexedPath Build()
        {
            var subItems = this.SubItems.ToDictionary(
                kvp => kvp.Key,
                kvp => (IReadOnlyList<SubItemTypePathReference>)kvp.Value);

            return new ContentUnitIndexedPath(this.Items, subItems);
        }

        public void IndexItem(ItemTypePathReference itemTypeReference)
        {
            this.Items.Add(itemTypeReference);
        }

        public void IndexSubItem(SubItemTypePathReference subItemTypeReference)
        {
            string typeName = subItemTypeReference.EntityTypeName.ItemName.Name;

            if (this.SubItems.TryGetValue(typeName, out var namedSubItems) == false)
            {
                namedSubItems = new List<SubItemTypePathReference>();
                this.SubItems.Add(typeName, namedSubItems);
            }

            namedSubItems.Add(subItemTypeReference);
        }
    }
}
