using System;
using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Parser.Build.Models.ItemReferences
{
    public class FirstPhaseResolvedItem
    {
        public FirstPhaseResolvedItem(
            FirstPhaseItemTypeReference itemReference,
            IReadOnlyList<FirstPhaseSubItemTypeReference>? subItemReferences = null)
        {
            this.ItemReference = itemReference;
            this.SubItemReferences = subItemReferences ?? Array.Empty<FirstPhaseSubItemTypeReference>();
        }

        public FirstPhaseItemTypeReference ItemReference { get; }

        public IReadOnlyList<FirstPhaseSubItemTypeReference> SubItemReferences { get; }
    }
}
