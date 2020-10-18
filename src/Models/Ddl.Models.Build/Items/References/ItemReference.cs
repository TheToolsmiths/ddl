using TheToolsmiths.Ddl.Models.Items;

namespace TheToolsmiths.Ddl.Models.Build.Items.References
{
    public class ItemReference : EntityReference
    {
        public ItemReference(ItemId itemId)
        {
            this.ItemId = itemId;
        }

        public ItemId ItemId { get; }

        public override string ToString()
        {
            return $"({this.ItemId})";
        }
    }
}
