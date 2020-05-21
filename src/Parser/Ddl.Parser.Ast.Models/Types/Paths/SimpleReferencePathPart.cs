using TheToolsmiths.Ddl.Parser.Ast.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Types.Paths
{
    public class SimpleReferencePathPart : TypeReferencePathPart
    {
        public SimpleReferencePathPart(Identifier name)
            : base(name)
        {
        }

        public override TypeReferencePathPartKind PartKind => TypeReferencePathPartKind.Simple;

        public override string ToString()
        {
            return this.Name.ToString();
        }
    }
}
