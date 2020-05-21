using TheToolsmiths.Ddl.Parser.Ast.Models.Literals;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Values
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