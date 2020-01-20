namespace TheToolsmiths.Ddl.Models.Operators
{
    public class OrOperator : IConditionalLogicalOperator
    {
        public ConditionalLogicalOperatorType LogicalOperatorType => ConditionalLogicalOperatorType.Or;
    }
}