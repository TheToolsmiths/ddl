namespace TheToolsmiths.Ddl.Models.Compiled.Values
{
    public class CompiledEmptyInitialization : CompiledValueInitialization
    {
        public override CompiledValueInitializationType InitializationKind => CompiledValueInitializationType.Empty;
    }
}
