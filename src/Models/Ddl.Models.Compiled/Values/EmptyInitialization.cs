namespace TheToolsmiths.Ddl.Models.Compiled.Values
{
    public class EmptyInitialization : ValueInitialization
    {
        public override ValueInitializationType InitializationKind => ValueInitializationType.Empty;
    }
}
