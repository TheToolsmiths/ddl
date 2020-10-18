using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Models.Types.Items
{
    public class ItemTypeName : TypeName
    {
        public ItemTypeName(TypeNameIdentifier itemName)
            : base(itemName)
        {
        }

        public override string ToString()
        {
            return this.ItemName.ToString();
        }
    }
}
