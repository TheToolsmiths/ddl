namespace TheToolsmiths.Ddl.Models.Build.Values
{
    public class EmptyInitialization : ValueInitialization
    {
        public override ValueInitializationType InitializationKind => ValueInitializationType.Empty;
    }
}
