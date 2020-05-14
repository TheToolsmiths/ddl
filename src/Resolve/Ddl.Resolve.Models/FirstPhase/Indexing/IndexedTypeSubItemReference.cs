using Ddl.Common.Models;
using Ddl.Resolve.Models.FirstPhase.TypePaths;

namespace Ddl.Resolve.Models.FirstPhase.Indexing
{
    public class IndexedTypeSubItemReference : IndexedTypeReference
    {
        public IndexedTypeSubItemReference(
            FirstPhaseTypeName fullDeclaredTypeName,
            ContentUnitId contentUnitId,
            ContentUnitItemId itemId,
            ContentUnitSubItemId subItemId)
            : base(fullDeclaredTypeName, contentUnitId)
        {
            this.ItemId = itemId;
            this.SubItemId = subItemId;
        }

        public ContentUnitItemId ItemId { get; }

        public ContentUnitSubItemId SubItemId { get; }
    }
}
