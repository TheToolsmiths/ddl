namespace TheToolsmiths.Ddl.Parser.Ast.Models.ConditionalExpressions
{
    public class AstConditionalExpression
    {
        private AstConditionalExpression(IAstConditionalExpressionElement root)
        {
            this.Root = root;
            this.IsEmpty = false;
        }

        private AstConditionalExpression()
        {
            this.Root = BoolLiteralExpression.CreateTrue();
            this.IsEmpty = true;
        }

        public IAstConditionalExpressionElement Root { get; }

        public bool IsEmpty { get; }

        public static AstConditionalExpression CreateEmpty()
        {
            return new AstConditionalExpression();
        }

        public static AstConditionalExpression Create(
            IAstConditionalExpressionElement expression)
        {
            return new AstConditionalExpression(expression);
        }
    }
}
