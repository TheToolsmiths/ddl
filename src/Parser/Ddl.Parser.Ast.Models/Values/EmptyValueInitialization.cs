namespace TheToolsmiths.Ddl.Parser.Ast.Models.Values
{
    public class EmptyValueInitialization : ValueInitialization
    {
        public override ValueInitializationType Type => ValueInitializationType.Empty;
    }
}