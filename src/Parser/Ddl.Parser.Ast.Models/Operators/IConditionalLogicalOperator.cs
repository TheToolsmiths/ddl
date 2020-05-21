namespace TheToolsmiths.Ddl.Parser.Ast.Models.Operators
{
    public interface IConditionalLogicalOperator : IOperator
    {
        ConditionalLogicalOperatorType LogicalOperatorType { get; }
    }
}
