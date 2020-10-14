using TheToolsmiths.Ddl.Models.Ast.Identifiers;

namespace TheToolsmiths.Ddl.Models.Ast.Types.Names
{
    public class SimpleTypeName : TypeName
    {
        public SimpleTypeName(Identifier name)
            : base(name)
        {
        }

        public override string ToString()
        {
            return this.Name.ToString();
        }
    }
}
