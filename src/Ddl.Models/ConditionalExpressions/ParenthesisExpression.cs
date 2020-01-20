namespace TheToolsmiths.Ddl.Models.ConditionalExpressions
{
    public class ParenthesisExpression : IConditionalExpressionElement
    {
        public ParenthesisExpression(IConditionalExpressionElement innerExpression)
        {
            this.InnerExpression = innerExpression;
        }

        public ConditionalExpressionElementType ElementType => ConditionalExpressionElementType.Parenthesis;

        public IConditionalExpressionElement InnerExpression { get; }
    }
}
