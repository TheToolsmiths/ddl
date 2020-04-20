namespace TheToolsmiths.Ddl.Parser.Models.ConditionalExpressions
{
    public class EmptyExpression : IConditionalExpressionElement
    {
        public ConditionalExpressionElementType ElementType => ConditionalExpressionElementType.Empty;
    }
}
