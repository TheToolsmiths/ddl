using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Models.TypePaths.Identifiers
{
    public class ResolvedSimpleIdentifierPathPart : ResolvedTypeIdentifierPathPart
    {
        public ResolvedSimpleIdentifierPathPart(Identifier name)
            : base(name)
        {
        }

        public override ResolvedTypeIdentifierPathPartKind PartKind => ResolvedTypeIdentifierPathPartKind.Simple;

        public override string ToString()
        {
            return this.Name.ToString();
        }
    }
}
