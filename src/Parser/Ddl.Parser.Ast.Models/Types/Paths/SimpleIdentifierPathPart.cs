using TheToolsmiths.Ddl.Parser.Ast.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Types.Paths
{
    public class SimpleIdentifierPathPart : TypeIdentifierPathPart
    {
        public SimpleIdentifierPathPart(Identifier name)
            : base(name)
        {
        }

        public override TypeIdentifierPathPartKind PartKind => TypeIdentifierPathPartKind.Simple;

        public override string ToString()
        {
            return this.Name.ToString();
        }
    }
}
