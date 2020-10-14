namespace TheToolsmiths.Ddl.Models.Ast.Values
{
    public class EmptyValueInitialization : ValueInitialization
    {
        public override ValueInitializationType Type => ValueInitializationType.Empty;
    }
}