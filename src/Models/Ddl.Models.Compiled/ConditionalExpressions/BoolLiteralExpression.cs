namespace TheToolsmiths.Ddl.Models.Compiled.ConditionalExpressions
{
    public class BoolLiteralExpression : IConditionalExpressionElement
    {
        public BoolLiteralExpression(bool value)
        {
            this.Value = value;
        }

        public bool Value { get; }

        public ConditionalExpressionElementType ElementType => ConditionalExpressionElementType.BooleanLiteral;

        public static BoolLiteralExpression True => new BoolLiteralExpression(true);

        public static BoolLiteralExpression False => new BoolLiteralExpression(false);
    }
}
