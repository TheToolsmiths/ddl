namespace TheToolsmiths.Ddl.Models.Values
{
    public class EmptyInitialization : ValueInitialization
    {
        public override ValueInitializationType InitializationKind => ValueInitializationType.Empty;
    }
}
