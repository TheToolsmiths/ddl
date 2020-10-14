namespace TheToolsmiths.Ddl.Models.Build.ConditionalExpressions
{
    public class NegateExpression : IConditionalExpressionElement
    {
        public NegateExpression(IConditionalExpressionElement innerExpression)
        {
            this.InnerExpression = innerExpression;
        }

        public ConditionalExpressionElementType ElementType => ConditionalExpressionElementType.Negate;

        public IConditionalExpressionElement InnerExpression { get; }
    }
}
