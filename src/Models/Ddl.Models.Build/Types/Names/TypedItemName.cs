namespace TheToolsmiths.Ddl.Models.Build.Types.Names
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
