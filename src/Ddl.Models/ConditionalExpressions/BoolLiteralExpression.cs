namespace TheToolsmiths.Ddl.Models.ConditionalExpressions
{
    public class BoolLiteralExpression : IConditionalExpressionElement
    {
        public BoolLiteralExpression(bool value)
        {
            this.Value = value;
        }

        public bool Value { get; }

        public ConditionalExpressionElementType ElementType => ConditionalExpressionElementType.BooleanLiteral;

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
