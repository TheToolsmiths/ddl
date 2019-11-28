namespace TheToolsmiths.Ddl.Parser.Models
{
    public class LiteralValueInitialization : ValueInitialization
    {
        public LiteralValueInitialization(LiteralValue literal)
        {
            Literal = literal;
        }

        public override ValueInitializationType Type => ValueInitializationType.Literal;

        public LiteralValue Literal { get; }
    }
}