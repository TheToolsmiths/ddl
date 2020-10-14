using TheToolsmiths.Ddl.Models.Build.ContentUnits;

namespace TheToolsmiths.Ddl.Models.Build.References.ItemReferences
{
    public class ContentUnitSubItemReference : ContentUnitEntityReference
    {
        public ContentUnitSubItemReference(
            ContentUnitId contentUnitId,
            ItemId itemId,
            SubItemId subItemId)
            : base(contentUnitId)
        {
            this.ItemId = itemId;
            this.SubItemId = subItemId;
        }

        public ItemId ItemId { get; }

        public SubItemId SubItemId { get; }

        public static ContentUnitSubItemReference Create(in ContentUnitId contentUnitId, SubItemReference subItemReference)
        {
            return new ContentUnitSubItemReference(contentUnitId, subItemReference.ItemId, subItemReference.SubItemId);
        }

        public override string ToString()
        {
            return $"[{this.ContentUnitId}] ({this.ItemId}:{this.SubItemId})";
        }
    }
}
