﻿using TheToolsmiths.Ddl.Models.ContentUnits;

namespace TheToolsmiths.Ddl.Models.References.ItemReferences
{
    public class SubItemReference : EntityReference
    {
        public SubItemReference(
            ItemId itemId,
            SubItemId subItemId)
        {
            this.ItemId = itemId;
            this.SubItemId = subItemId;
        }

        public ItemId ItemId { get; }

        public SubItemId SubItemId { get; }

        public override string ToString()
        {
            return $"({this.ItemId}:{this.SubItemId})";
        }
    }
}
