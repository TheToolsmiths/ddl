namespace TheToolsmiths.Ddl.Parser.Models
{
    public class EmptyValueInitialization : ValueInitialization
    {
        public override ValueInitializationType Type => ValueInitializationType.Empty;
    }
}