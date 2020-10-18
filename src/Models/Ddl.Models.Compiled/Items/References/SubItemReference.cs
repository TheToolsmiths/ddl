using TheToolsmiths.Ddl.Models.Items;

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
    }
}
