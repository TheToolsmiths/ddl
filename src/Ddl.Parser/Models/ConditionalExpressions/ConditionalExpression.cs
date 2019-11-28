namespace TheToolsmiths.Ddl.Parser.Models.ConditionalExpressions
{
    public class ConditionalExpression
    {
        private ConditionalExpression(IConditionalExpressionElement root)
        {
            Root = root;
            IsEmpty = false;
        }

        private ConditionalExpression()
        {
            Root = BoolLiteralExpression.CreateTrue();
            IsEmpty = true;
        }

        public IConditionalExpressionElement Root { get; }

        public bool IsEmpty { get; }

        public static ConditionalExpression CreateEmpty()
        {
            return new ConditionalExpression();
        }

        public static ConditionalExpression Create(
            IConditionalExpressionElement expression)
        {
            return new ConditionalExpression(expression);
        }
    }
}
