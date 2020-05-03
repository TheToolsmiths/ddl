using Ddl.Common.Models;
using Ddl.Resolve.Models.FirstPhase.TypePaths;

namespace Ddl.Resolve.Models.FirstPhase.TypeReferences
{
    public class FirstPhaseTypePathSubItemReference : FirstPhaseTypePathReference
    {
        public FirstPhaseTypePathSubItemReference(
            FirstPhaseTypeName typeName,
            ContentUnitItemId itemId,
            ContentUnitSubItemId subItemId)
            : base(typeName)
        {
            this.ItemId = itemId;
            this.SubItemId = subItemId;
        }

        public ContentUnitItemId ItemId { get; }

        public ContentUnitSubItemId SubItemId { get; }
    }
}