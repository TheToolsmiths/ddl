namespace TheToolsmiths.Ddl.Models.Build.ConditionalExpressions
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
            this.Root = BoolLiteralExpression.True;
            this.IsEmpty = true;
        }

        public IConditionalExpressionElement Root { get; }

        public bool IsEmpty { get; }

        public static ConditionalExpression False => new ConditionalExpression(BoolLiteralExpression.False);

        public static ConditionalExpression True => new ConditionalExpression(BoolLiteralExpression.True);

        public static ConditionalExpression Empty => new ConditionalExpression();

        public static ConditionalExpression Create(
            IConditionalExpressionElement expression)
        {
            return new ConditionalExpression(expression);
        }

        public static ConditionalExpression CreateOr(params IConditionalExpressionElement[] elements)
        {
            var root = LogicalExpression.CreateOr(elements);
            return new ConditionalExpression(root);
        }

        public static ConditionalExpression CreateAnd(params IConditionalExpressionElement[] elements)
        {
            throw new System.NotImplementedException();
        }
    }
}
