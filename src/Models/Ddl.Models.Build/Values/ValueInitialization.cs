using TheToolsmiths.Ddl.Models.Literals;

namespace TheToolsmiths.Ddl.Models.Build.Values
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
