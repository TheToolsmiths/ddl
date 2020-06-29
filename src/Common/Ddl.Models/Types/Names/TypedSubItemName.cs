namespace TheToolsmiths.Ddl.Models.Types.Names
{
    public class TypedSubItemName : TypeName
    {
        public TypedSubItemName(TypeNameIdentifier itemNameIdentifier, TypeNameIdentifier subItemNameIdentifier)
            : base(itemNameIdentifier)
        {
            this.SubItemNameIdentifier = subItemNameIdentifier;
        }

        public TypeNameIdentifier SubItemNameIdentifier { get; }

        public override string ToString()
        {
            return $"{this.ItemNameIdentifier}::{this.SubItemNameIdentifier}";
        }
    }
}
