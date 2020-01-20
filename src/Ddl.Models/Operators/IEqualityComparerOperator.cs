namespace TheToolsmiths.Ddl.Models.Operators
{
    public interface IEqualityComparerOperator : IOperator
    {
        EqualityComparerOperatorType EqualityComparerOperatorType { get; }
    }
}
