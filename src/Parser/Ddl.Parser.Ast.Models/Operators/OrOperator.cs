namespace TheToolsmiths.Ddl.Parser.Ast.Models.Operators
{
    public class OrOperator : IConditionalLogicalOperator
    {
        public ConditionalLogicalOperatorType LogicalOperatorType => ConditionalLogicalOperatorType.Or;
    }
}