using TheToolsmiths.Ddl.Models.ContentUnits;

namespace TheToolsmiths.Ddl.Models.References.ItemReferences
{
    public class SubItemReference : EntityReference
    {
        public SubItemReference(
            ContentUnitItemId itemId,
            ContentUnitSubItemId subItemId)
        {
            this.ItemId = itemId;
            this.SubItemId = subItemId;
        }

        public ContentUnitItemId ItemId { get; }

        public ContentUnitSubItemId SubItemId { get; }

        public override string ToString()
        {
            return $"({this.ItemId}:{this.SubItemId})";
        }
    }
}
