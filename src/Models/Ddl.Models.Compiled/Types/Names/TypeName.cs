namespace TheToolsmiths.Ddl.Models.Compiled.Types.Names
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
