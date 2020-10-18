namespace TheToolsmiths.Ddl.Models.ConditionalExpressions
{
    public class EmptyExpression : IConditionalExpressionElement
    {
        public ConditionalExpressionElementType ElementType => ConditionalExpressionElementType.Empty;
    }
}
