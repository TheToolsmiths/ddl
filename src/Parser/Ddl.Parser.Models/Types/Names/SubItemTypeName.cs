namespace TheToolsmiths.Ddl.Parser.Models.Types.Names
{
    public class SubItemTypeName : TypeName
    {
        public SubItemTypeName(TypeNameIdentifier itemNameIdentifier, TypeNameIdentifier subItemNameIdentifier)
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
