namespace TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Identifiers
{
    public abstract class TypeIdentifierPathPart
    {
        protected TypeIdentifierPathPart(string name)
        {
            this.Name = name;
        }

        public abstract TypeIdentifierPathPartKind PartKind { get; }

        public string Name { get; }
    }
}
