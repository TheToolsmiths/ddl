namespace TheToolsmiths.Ddl.Parser.Models
{
    public abstract class ValueInitialization
    {
        public abstract ValueInitializationType Type { get; }

        public static ValueInitialization CreateEmpty()
        {
            return new EmptyValueInitialization();
        }

        public static ValueInitialization CreateLiteral(LiteralInitialization literal)
        {
            return new LiteralValueInitialization(literal);
        }
    }
}
