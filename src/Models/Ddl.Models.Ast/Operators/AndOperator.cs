namespace TheToolsmiths.Ddl.Models.Ast.Operators
{
    public class AndOperator : IConditionalLogicalOperator
    {
        public ConditionalLogicalOperatorType LogicalOperatorType => ConditionalLogicalOperatorType.And;
    }
}
