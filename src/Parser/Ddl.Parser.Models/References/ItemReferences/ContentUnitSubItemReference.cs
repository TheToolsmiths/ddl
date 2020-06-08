using Ddl.Common.Models;

namespace TheToolsmiths.Ddl.Parser.Models.References.ItemReferences
{
    public class ContentUnitSubItemReference : ContentUnitEntityReference
    {
        public ContentUnitSubItemReference(
            ContentUnitId contentUnitId,
            ContentUnitItemId itemId,
            ContentUnitSubItemId subItemId)
            : base(contentUnitId)
        {
            this.ItemId = itemId;
            this.SubItemId = subItemId;
        }

        public ContentUnitItemId ItemId { get; }

        public ContentUnitSubItemId SubItemId { get; }

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
