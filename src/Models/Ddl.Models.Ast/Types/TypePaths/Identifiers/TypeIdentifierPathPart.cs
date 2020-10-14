using TheToolsmiths.Ddl.Models.Ast.Identifiers;

namespace TheToolsmiths.Ddl.Models.Ast.Types.TypePaths.Identifiers
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
