namespace TheToolsmiths.Ddl.Parser.Models.Types.Names
{
    public abstract class TypeName
    {
        protected TypeName(TypeNameIdentifier itemNameIdentifier)
        {
            this.ItemNameIdentifier = itemNameIdentifier;
        }

        public TypeNameIdentifier ItemNameIdentifier { get; }
    }
}
