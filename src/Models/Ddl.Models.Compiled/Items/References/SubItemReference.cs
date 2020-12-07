﻿using TheToolsmiths.Ddl.Models.ItemIds;

namespace TheToolsmiths.Ddl.Models.Compiled.Items.References
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

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 31 + this.ItemId.GetHashCode();
                hash = hash * 31 + this.SubItemId.GetHashCode();
                return hash;
            }
        }
    }
}
