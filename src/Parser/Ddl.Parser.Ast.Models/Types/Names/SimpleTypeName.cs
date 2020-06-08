using TheToolsmiths.Ddl.Parser.Ast.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names
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
