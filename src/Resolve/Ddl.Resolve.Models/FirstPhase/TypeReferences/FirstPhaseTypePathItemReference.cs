using Ddl.Common.Models;
using Ddl.Resolve.Models.FirstPhase.TypePaths;

namespace Ddl.Resolve.Models.FirstPhase.TypeReferences
{
    public class FirstPhaseTypePathItemReference : FirstPhaseTypePathReference
    {
        public FirstPhaseTypePathItemReference(FirstPhaseTypeName typeName, ContentUnitItemId itemId)
            : base(typeName)
        {
            this.ItemId = itemId;
        }

        public ContentUnitItemId ItemId { get; }
    }
}