using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Identifiers
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
