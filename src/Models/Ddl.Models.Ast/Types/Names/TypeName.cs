using TheToolsmiths.Ddl.Models.Ast.Identifiers;

namespace TheToolsmiths.Ddl.Models.Ast.Types.Names
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
