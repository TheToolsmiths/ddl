using Ddl.Common.Models;
using Ddl.Resolve.Models.FirstPhase.TypePaths;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase
{
    public class IndexedTypeItemReference : IndexedTypeReference
    {
        public IndexedTypeItemReference(
            FirstPhaseTypeName fullDeclaredTypeName,
            ContentUnitId contentUnitId,
            ContentUnitItemId itemId)
            : base(fullDeclaredTypeName, contentUnitId)
        {
            this.ItemId = itemId;
        }

        public ContentUnitItemId ItemId { get; }
    }
}
