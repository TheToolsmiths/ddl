namespace TheToolsmiths.Ddl.Parser.Ast.Models.ConditionalExpressions
{
    public class NegateExpression : IAstConditionalExpressionElement
    {
        public NegateExpression(IAstConditionalExpressionElement innerExpression)
        {
            this.InnerExpression = innerExpression;
        }

        public AstConditionalExpressionElementType ElementType => AstConditionalExpressionElementType.Negate;

        public IAstConditionalExpressionElement InnerExpression { get; }
    }
}
