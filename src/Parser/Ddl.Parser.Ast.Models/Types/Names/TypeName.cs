using TheToolsmiths.Ddl.Parser.Ast.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names
{
    public abstract class TypeName
    {
        protected TypeName(Identifier name)
        {
            this.Name = name;
        }

        public Identifier Name { get; }

        public abstract override string ToString();
    }
}
