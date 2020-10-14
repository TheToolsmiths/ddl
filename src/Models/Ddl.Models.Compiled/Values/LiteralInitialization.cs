using TheToolsmiths.Ddl.Models.Compiled.Literals;

namespace TheToolsmiths.Ddl.Models.Compiled.Values
{
    public class LiteralInitialization : ValueInitialization
    {
        public LiteralInitialization(LiteralValue literal)
        {
            this.Literal = literal;
        }

        public override ValueInitializationType InitializationKind => ValueInitializationType.Literal;

        public LiteralValue Literal { get; }
    }
}
