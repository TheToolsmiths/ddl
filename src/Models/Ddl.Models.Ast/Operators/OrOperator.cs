namespace TheToolsmiths.Ddl.Models.Ast.Operators
{
    public class OrOperator : IConditionalLogicalOperator
    {
        public ConditionalLogicalOperatorType LogicalOperatorType => ConditionalLogicalOperatorType.Or;
    }
}