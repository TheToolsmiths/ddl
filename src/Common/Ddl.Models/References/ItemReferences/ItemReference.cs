using TheToolsmiths.Ddl.Models.ContentUnits;

namespace TheToolsmiths.Ddl.Models.References.ItemReferences
{
    public class ItemReference : EntityReference
    {
        public ItemReference(ContentUnitItemId itemId)
        {
            this.ItemId = itemId;
        }

        public ContentUnitItemId ItemId { get; }

        public override string ToString()
        {
            return $"({this.ItemId})";
        }
    }
}
