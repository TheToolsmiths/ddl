using Ddl.Common.Models;
using Ddl.Resolve.Models.FirstPhase.TypePaths;

namespace Ddl.Resolve.Models.FirstPhase.Indexing
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
