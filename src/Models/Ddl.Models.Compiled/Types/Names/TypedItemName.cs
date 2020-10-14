namespace TheToolsmiths.Ddl.Models.Compiled.Types.Names
{
    public class TypedItemName : TypeName
    {
        public TypedItemName(TypeNameIdentifier itemName)
            : base(itemName)
        {
        }

        public override string ToString()
        {
            return this.ItemName.ToString();
        }
    }
}
