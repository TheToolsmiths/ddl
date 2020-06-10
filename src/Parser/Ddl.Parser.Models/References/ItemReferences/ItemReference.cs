using TheToolsmiths.Ddl.Models;

namespace TheToolsmiths.Ddl.Parser.Models.References.ItemReferences
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
