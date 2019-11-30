namespace TheToolsmiths.Ddl.Models
{
    public class EmptyValueInitialization : ValueInitialization
    {
        public override ValueInitializationType Type => ValueInitializationType.Empty;
    }
}