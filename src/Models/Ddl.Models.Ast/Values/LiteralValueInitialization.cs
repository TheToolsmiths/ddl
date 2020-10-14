using TheToolsmiths.Ddl.Models.Ast.Literals;

namespace TheToolsmiths.Ddl.Models.Ast.Values
{
    public class LiteralValueInitialization : ValueInitialization
    {
        public LiteralValueInitialization(LiteralValue literal)
        {
            this.Literal = literal;
        }

        public override ValueInitializationType Type => ValueInitializationType.Literal;

        public LiteralValue Literal { get; }
    }
}
