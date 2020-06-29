using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.ContentUnits.Items.ItemReferences;

namespace TheToolsmiths.Ddl.Models.ContentUnits.Items
{
    public abstract class RootItemBase : IRootItem
    {
        protected RootItemBase(
            TypedItemReference itemReference,
            IReadOnlyList<TypedSubItemReference>? subItemReferences = null)
        {
            this.ItemReference = itemReference;
            this.SubItemReferences = subItemReferences ?? Array.Empty<TypedSubItemReference>();
        }

        public TypedItemReference ItemReference { get; }

        public IReadOnlyList<TypedSubItemReference> SubItemReferences { get; }
    }
}
