namespace TheToolsmiths.Ddl.Models.Ast.ConditionalExpressions
{
    public class ParenthesisExpression : IAstConditionalExpressionElement
    {
        public ParenthesisExpression(IAstConditionalExpressionElement innerExpression)
        {
            this.InnerExpression = innerExpression;
        }

        public AstConditionalExpressionElementType ElementType => AstConditionalExpressionElementType.Parenthesis;

        public IAstConditionalExpressionElement InnerExpression { get; }
    }
}
