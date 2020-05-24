namespace TheToolsmiths.Ddl.Parser.Models.Values
{
    public class EmptyValueInitialization : ValueInitialization
    {
        public override ValueInitializationType InitializationKind => ValueInitializationType.Empty;
    }
}
