namespace TheToolsmiths.Ddl.Models.Build.Types.Names
{
    public abstract class TypeName
    {
        protected TypeName(TypeNameIdentifier itemName)
        {
            this.ItemName = itemName;
        }

        public TypeNameIdentifier ItemName { get; }

        public abstract override string ToString();
    }
}
