using Ddl.Common.Models;

namespace Ddl.Resolve.Models.ItemReferences
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
