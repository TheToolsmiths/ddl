using Ddl.Common.Models;

namespace Ddl.Resolve.Models.FirstPhase.Items
{
    public class FirstPhaseItemTypeReference : FirstPhaseTypeReference
    {
        public FirstPhaseItemTypeReference(ContentUnitItemId itemId)
        {
            this.ItemId = itemId;
        }

        public ContentUnitItemId ItemId { get; }
    }
}
