namespace TheToolsmiths.Ddl.Models.Compiled.Types.Names
{
    public class TypedSubItemName : TypeName
    {
        public TypedSubItemName(TypeNameIdentifier itemName, TypeNameIdentifier subItemNameIdentifier)
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
