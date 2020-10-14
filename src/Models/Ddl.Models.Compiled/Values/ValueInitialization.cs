using TheToolsmiths.Ddl.Models.Compiled.Literals;

namespace TheToolsmiths.Ddl.Models.Compiled.Values
{
    public abstract class ValueInitialization
    {
        public abstract ValueInitializationType InitializationKind { get; }

        public static ValueInitialization CreateEmpty()
        {
            return new EmptyInitialization();
        }

        public static ValueInitialization CreateLiteral(LiteralValue literal)
        {
            return new LiteralInitialization(literal);
        }
    }
}
