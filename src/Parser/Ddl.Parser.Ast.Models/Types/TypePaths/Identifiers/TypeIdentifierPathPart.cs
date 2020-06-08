using TheToolsmiths.Ddl.Parser.Ast.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Types.TypePaths.Identifiers
{
    public abstract class TypeIdentifierPathPart
    {
        protected TypeIdentifierPathPart(Identifier name)
        {
            this.Name = name;
        }

        public Identifier Name { get; }
    }
}
