using TheToolsmiths.Ddl.Models.Build.Literals;

namespace TheToolsmiths.Ddl.Models.Build.Values
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
