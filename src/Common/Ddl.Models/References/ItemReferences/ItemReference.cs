using TheToolsmiths.Ddl.Models.ContentUnits;

namespace TheToolsmiths.Ddl.Models.References.ItemReferences
{
    public class ItemReference : EntityReference
    {
        public ItemReference(ItemId itemId)
        {
            this.ItemId = itemId;
        }

        public ItemId ItemId { get; }

        public override string ToString()
        {
            return $"({this.ItemId})";
        }
    }
}
