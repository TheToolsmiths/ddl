namespace TheToolsmiths.Ddl.Parser.Models.Operators
{
    public class AndOperator : IConditionalLogicalOperator
    {
        public ConditionalLogicalOperatorType LogicalOperatorType => ConditionalLogicalOperatorType.And;
    }
}
