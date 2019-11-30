namespace TheToolsmiths.Ddl.Models.ConditionalExpressions
{
    public class NegateExpression : IConditionalExpressionElement
    {
        public NegateExpression(IConditionalExpressionElement innerExpression)
        {
            InnerExpression = innerExpression;
        }

        public ConditionalExpressionElementType ElementType => ConditionalExpressionElementType.Negate;

        public IConditionalExpressionElement InnerExpression { get; }
    }
}
