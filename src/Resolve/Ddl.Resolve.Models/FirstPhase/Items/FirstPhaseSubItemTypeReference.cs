using Ddl.Common.Models;

namespace Ddl.Resolve.Models.FirstPhase.Items
{
    public class FirstPhaseSubItemTypeReference : FirstPhaseTypeReference
    {
        public FirstPhaseSubItemTypeReference(ContentUnitItemId itemId, ContentUnitSubItemId subItemId)
        {
            this.ItemId = itemId;
            this.SubItemId = subItemId;
        }

        public ContentUnitItemId ItemId { get; }

        public ContentUnitSubItemId SubItemId { get; }
    }
}
