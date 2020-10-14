namespace TheToolsmiths.Ddl.Models.Ast.ConditionalExpressions
{
    public class BoolLiteralExpression : IAstConditionalExpressionElement
    {
        public BoolLiteralExpression(bool value)
        {
            this.Value = value;
        }

        public bool Value { get; }

        public AstConditionalExpressionElementType ElementType => AstConditionalExpressionElementType.BooleanLiteral;

        public static BoolLiteralExpression CreateTrue()
        {
            return new BoolLiteralExpression(true);
        }

        public static BoolLiteralExpression CreateFalse()
        {
            return new BoolLiteralExpression(false);
        }
    }
}
