namespace TheToolsmiths.Ddl.Parser.Ast.Models.ConditionalExpressions
{
    public class EmptyExpression : IAstConditionalExpressionElement
    {
        public AstConditionalExpressionElementType ElementType => AstConditionalExpressionElementType.Empty;
    }
}
