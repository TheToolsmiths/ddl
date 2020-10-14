namespace TheToolsmiths.Ddl.Models.Build.ConditionalExpressions
{
    public class EmptyExpression : IConditionalExpressionElement
    {
        public ConditionalExpressionElementType ElementType => ConditionalExpressionElementType.Empty;
    }
}
