using TheToolsmiths.Ddl.Parser.Models.Literals;

namespace TheToolsmiths.Ddl.Parser.Models.Values
{
    public abstract class ValueInitialization
    {
        public abstract ValueInitializationType InitializationKind { get; }

        public static ValueInitialization CreateEmpty()
        {
            return new EmptyValueInitialization();
        }

        public static ValueInitialization CreateLiteral(LiteralValue literal)
        {
            return new LiteralValueInitialization(literal);
        }
    }
}
