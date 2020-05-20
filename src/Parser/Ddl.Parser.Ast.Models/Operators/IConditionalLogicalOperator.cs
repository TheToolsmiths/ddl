namespace TheToolsmiths.Ddl.Parser.Models.Operators
{
    public interface IConditionalLogicalOperator : IOperator
    {
        ConditionalLogicalOperatorType LogicalOperatorType { get; }
    }
}
