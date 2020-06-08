namespace TheToolsmiths.Ddl.Parser.Models.Types.Names
{
    public class ItemTypeName : TypeName
    {
        public ItemTypeName(TypeNameIdentifier itemNameIdentifier)
            : base(itemNameIdentifier)
        {
        }

        public override string ToString()
        {
            return this.ItemNameIdentifier.ToString();
        }
    }
}
