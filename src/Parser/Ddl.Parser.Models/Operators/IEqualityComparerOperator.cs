namespace TheToolsmiths.Ddl.Parser.Models.Operators
{
    public interface IEqualityComparerOperator : IOperator
    {
        EqualityComparerOperatorType EqualityComparerOperatorType { get; }
    }
}
