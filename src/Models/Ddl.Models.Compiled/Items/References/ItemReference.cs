using TheToolsmiths.Ddl.Models.ItemIds;

namespace TheToolsmiths.Ddl.Models.Compiled.Items.References
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

        public override int GetHashCode()
        {
            return this.ItemId.GetHashCode();
        }
    }
}
