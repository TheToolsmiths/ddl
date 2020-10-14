namespace TheToolsmiths.Ddl.Models.Ast.Operators
{
    public interface IConditionalLogicalOperator : IOperator
    {
        ConditionalLogicalOperatorType LogicalOperatorType { get; }
    }
}
