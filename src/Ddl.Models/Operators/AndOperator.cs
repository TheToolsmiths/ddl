namespace TheToolsmiths.Ddl.Models.Operators
{
    public class AndOperator : IConditionalLogicalOperator
    {
        public ConditionalLogicalOperatorType LogicalOperatorType => ConditionalLogicalOperatorType.And;
    }
}
