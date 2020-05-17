using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Models.Types.Paths
{
    public abstract class TypeIdentifierPathPart
    {
        protected TypeIdentifierPathPart(Identifier name)
        {
            this.Name = name;
        }

        public abstract TypeIdentifierPathPartKind PartKind { get; }

        public Identifier Name { get; }
    }
}
