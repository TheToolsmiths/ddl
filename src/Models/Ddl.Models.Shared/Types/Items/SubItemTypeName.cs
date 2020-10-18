using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Models.Types.Items
{
    public class SubItemTypeName : TypeName
    {
        public SubItemTypeName(TypeNameIdentifier itemName, TypeNameIdentifier subItemNameIdentifier)
            : base(itemName)
        {
            this.SubItemNameIdentifier = subItemNameIdentifier;
        }

        public TypeNameIdentifier SubItemNameIdentifier { get; }

        public override string ToString()
        {
            return $"{this.ItemName}::{this.SubItemNameIdentifier}";
        }
    }
}
