namespace TheToolsmiths.Ddl.Parser.Models
{
    public class LiteralValueInitialization : ValueInitialization
    {
        public LiteralValueInitialization(LiteralInitialization literal)
        {
            Literal = literal;
        }

        public override ValueInitializationType Type => ValueInitializationType.Literal;

        public LiteralInitialization Literal { get; }
    }
}