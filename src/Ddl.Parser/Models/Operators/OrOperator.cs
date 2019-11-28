namespace TheToolsmiths.Ddl.Parser.Models.Operators
{
    public class OrOperator : IConditionalLogicalOperator
    {
        public ConditionalLogicalOperatorType LogicalOperatorType => ConditionalLogicalOperatorType.Or;
    }
}