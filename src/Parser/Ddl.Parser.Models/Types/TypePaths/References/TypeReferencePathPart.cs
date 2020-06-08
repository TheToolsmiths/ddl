namespace TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.References
{
    public abstract class TypeReferencePathPart
    {
        protected TypeReferencePathPart(string name)
        {
            this.Name = name;
        }

        public abstract TypeReferencePathPartKind PartKind { get; }

        public string Name { get; }
    }
}
