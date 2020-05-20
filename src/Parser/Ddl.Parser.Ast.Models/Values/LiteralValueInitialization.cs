using TheToolsmiths.Ddl.Parser.Models.Literals;

namespace TheToolsmiths.Ddl.Parser.Models.Values
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