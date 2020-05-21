namespace TheToolsmiths.Ddl.Parser.Ast.Models.Operators
{
    public class AndOperator : IConditionalLogicalOperator
    {
        public ConditionalLogicalOperatorType LogicalOperatorType => ConditionalLogicalOperatorType.And;
    }
}
