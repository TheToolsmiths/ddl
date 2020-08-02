using TheToolsmiths.Ddl.Models.ContentUnits;

namespace TheToolsmiths.Ddl.Models.References.ItemReferences
{
    public class ContentUnitItemReference : ContentUnitEntityReference
    {
        public ContentUnitItemReference(ContentUnitId contentUnitId, ItemId itemId)
            : base(contentUnitId)
        {
            this.ItemId = itemId;
        }

        public ItemId ItemId { get; }

        public static ContentUnitItemReference Create(in ContentUnitId contentUnitId, ItemReference itemReference)
        {
            return new ContentUnitItemReference(contentUnitId, itemReference.ItemId);
        }

        public override string ToString()
        {
            return $"[{this.ContentUnitId}] ({this.ItemId})";
        }
    }
}
