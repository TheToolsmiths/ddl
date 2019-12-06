namespace TheToolsmiths.Ddl.Models.ConditionalExpressions
{
    public class ConditionalExpression
    {
        private ConditionalExpression(IConditionalExpressionElement root)
        {
            this.Root = root;
            this.IsEmpty = false;
        }

        private ConditionalExpression()
        {
            this.Root = BoolLiteralExpression.CreateTrue();
            this.IsEmpty = true;
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
