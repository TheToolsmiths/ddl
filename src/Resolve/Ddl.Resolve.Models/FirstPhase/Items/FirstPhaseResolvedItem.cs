using System;
using System.Collections.Generic;
using Ddl.Resolve.Models.FirstPhase.Items.Content;
using Ddl.Resolve.Models.TypeReferences;

namespace Ddl.Resolve.Models.FirstPhase.Items
{
    public class FirstPhaseResolvedItem
    {
        public FirstPhaseResolvedItem(
            FirstPhaseResolvedItemContent content,
            FirstPhaseItemTypeReference? itemReference,
            IReadOnlyList<FirstPhaseSubItemTypeReference>? subItemReferences = null)
        {
            this.Content = content;
            this.ItemReference = itemReference;
            this.SubItemReferences = subItemReferences ?? Array.Empty<FirstPhaseSubItemTypeReference>();
        }

        public FirstPhaseResolvedItemContent Content { get; }

        public FirstPhaseItemTypeReference? ItemReference { get; }

        public IReadOnlyList<FirstPhaseSubItemTypeReference> SubItemReferences { get; }
    }
}
