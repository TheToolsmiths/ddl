using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Models.Types.Items
{
    public class SubItemTypeName : TypeName
    {
        public SubItemTypeName(TypeNameIdentifier itemName, TypeNameIdentifier subItemName)
            : base(itemName)
        {
            this.SubItemName = subItemName;
        }

        public TypeNameIdentifier SubItemName { get; }

        public override string ToString()
        {
            return $"{this.ItemName}::{this.SubItemName}";
        }
    }
}
