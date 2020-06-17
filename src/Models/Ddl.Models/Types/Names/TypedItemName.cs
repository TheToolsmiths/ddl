namespace TheToolsmiths.Ddl.Models.Types.Names
{
    public class TypedItemName : TypeName
    {
        public TypedItemName(TypeNameIdentifier itemNameIdentifier)
            : base(itemNameIdentifier)
        {
        }

        public override string ToString()
        {
            return this.ItemNameIdentifier.ToString();
        }
    }
}
