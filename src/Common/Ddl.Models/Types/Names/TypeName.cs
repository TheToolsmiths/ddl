namespace TheToolsmiths.Ddl.Models.Types.Names
{
    public abstract class TypeName
    {
        protected TypeName(TypeNameIdentifier itemNameIdentifier)
        {
            this.ItemNameIdentifier = itemNameIdentifier;
        }

        public TypeNameIdentifier ItemNameIdentifier { get; }

        public abstract override string ToString();
    }
}
