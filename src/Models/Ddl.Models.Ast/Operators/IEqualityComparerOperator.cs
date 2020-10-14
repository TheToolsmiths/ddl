namespace TheToolsmiths.Ddl.Models.Ast.Operators
{
    public interface IEqualityComparerOperator : IOperator
    {
        EqualityComparerOperatorType EqualityComparerOperatorType { get; }
    }
}
