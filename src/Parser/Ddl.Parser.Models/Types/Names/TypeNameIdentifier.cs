namespace TheToolsmiths.Ddl.Parser.Models.Types.Names
{
    public abstract class TypeNameIdentifier
    {
        protected TypeNameIdentifier(string name)
        {
            this.Name = name;
        }

        public abstract TypeNameIdentifierKind IdentifierKind { get; }

        public string Name { get; }
    }
}
