namespace TheToolsmiths.Ddl.Models.Ast.ConditionalExpressions
{
    public class EmptyExpression : IAstConditionalExpressionElement
    {
        public AstConditionalExpressionElementType ElementType => AstConditionalExpressionElementType.Empty;
    }
}
