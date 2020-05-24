using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Models.TypePaths.Identifiers
{
    public abstract class ResolvedTypeIdentifierPathPart
    {
        protected ResolvedTypeIdentifierPathPart(Identifier name)
        {
            this.Name = name;
        }

        public abstract ResolvedTypeIdentifierPathPartKind PartKind { get; }

        public Identifier Name { get; }
    }
}
