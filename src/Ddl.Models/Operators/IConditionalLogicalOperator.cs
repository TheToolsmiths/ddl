namespace TheToolsmiths.Ddl.Models.Operators
{
    public interface IConditionalLogicalOperator : IOperator
    {
        ConditionalLogicalOperatorType LogicalOperatorType { get; }
    }
}
