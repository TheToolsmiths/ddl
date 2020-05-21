namespace TheToolsmiths.Ddl.Parser.Ast.Models.ConditionalExpressions
{
    public class EmptyExpression : IConditionalExpressionElement
    {
        public ConditionalExpressionElementType ElementType => ConditionalExpressionElementType.Empty;
    }
}
