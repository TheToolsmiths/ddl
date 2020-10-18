using TheToolsmiths.Ddl.Models.Literals;

namespace TheToolsmiths.Ddl.Models.Compiled.Values
{
    public class CompiledLiteralInitialization : CompiledValueInitialization
    {
        public CompiledLiteralInitialization(LiteralValue literal)
        {
            this.Literal = literal;
        }

        public override CompiledValueInitializationType InitializationKind => CompiledValueInitializationType.Literal;

        public LiteralValue Literal { get; }
    }
}
