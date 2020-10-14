using TheToolsmiths.Ddl.Models.Ast.Identifiers;

namespace TheToolsmiths.Ddl.Models.Ast.Types.TypePaths.Identifiers
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
