using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Models.TypePaths.References
{
    public abstract class TypeReferencePathPart
    {
        protected TypeReferencePathPart(Identifier name)
        {
            this.Name = name;
        }

        public abstract TypeReferencePathPartKind PartKind { get; }

        public Identifier Name { get; }
    }
}
