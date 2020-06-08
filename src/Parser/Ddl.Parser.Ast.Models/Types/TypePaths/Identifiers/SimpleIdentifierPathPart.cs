using TheToolsmiths.Ddl.Parser.Ast.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Types.TypePaths.Identifiers
{
    public class SimpleIdentifierPathPart : TypeIdentifierPathPart
    {
        public SimpleIdentifierPathPart(Identifier name)
            : base(name)
        {
        }

        public override string ToString()
        {
            return this.Name.ToString();
        }
    }
}
