using System;
using System.Collections.Generic;
using Ddl.Resolve.Models.FirstPhase.Items.Content;
using Ddl.Resolve.Models.FirstPhase.TypeReferences;

namespace Ddl.Resolve.Models.FirstPhase.Items
{
    public class FirstPhaseResolvedItem
    {
        public FirstPhaseResolvedItem(
            FirstPhaseResolvedItemContent content,
            FirstPhaseTypePathItemReference? itemReference,
            IReadOnlyList<FirstPhaseTypePathSubItemReference>? subItemReferences = null)
        {
            this.Content = content;
            this.ItemReference = itemReference;
            this.SubItemReferences = subItemReferences ?? Array.Empty<FirstPhaseTypePathSubItemReference>();
        }

        public FirstPhaseResolvedItemContent Content { get; }

        public FirstPhaseTypePathItemReference? ItemReference { get; }

        public IReadOnlyList<FirstPhaseTypePathSubItemReference> SubItemReferences { get; }
    }
}
