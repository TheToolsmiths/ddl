using TheToolsmiths.Ddl.Models.Literals;

namespace TheToolsmiths.Ddl.Models.Compiled.Values
{
    public abstract class CompiledValueInitialization
    {
        public abstract CompiledValueInitializationType InitializationKind { get; }

        public static CompiledValueInitialization CreateEmpty()
        {
            return new CompiledEmptyInitialization();
        }

        public static CompiledValueInitialization CreateLiteral(LiteralValue literal)
        {
            return new CompiledLiteralInitialization(literal);
        }
    }
}
