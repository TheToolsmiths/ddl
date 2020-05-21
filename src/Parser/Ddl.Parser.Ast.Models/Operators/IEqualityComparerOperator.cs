namespace TheToolsmiths.Ddl.Parser.Ast.Models.Operators
{
    public interface IEqualityComparerOperator : IOperator
    {
        EqualityComparerOperatorType EqualityComparerOperatorType { get; }
    }
}
