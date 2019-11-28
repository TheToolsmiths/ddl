namespace TheToolsmiths.Ddl.Parser.Models.ConditionalExpressions
{
    public class BoolLiteralExpression : IConditionalExpressionElement
    {
        public BoolLiteralExpression(bool value)
        {
            Value = value;
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
