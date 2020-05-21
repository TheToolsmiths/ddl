using TheToolsmiths.Ddl.Parser.Ast.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Types.Paths
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
