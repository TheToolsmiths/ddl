namespace TheToolsmiths.Ddl.Models.Compiled.ConditionalExpressions
{
    public class DefineCheckExpression : IConditionalExpressionElement
    {
        public DefineCheckExpression(string identifier)
        {
            this.Identifier = identifier;
        }

        public ConditionalExpressionElementType ElementType => ConditionalExpressionElementType.Defined;

        public string Identifier { get; }

        public static DefineCheckExpression CreateDefined(string identifier)
        {
            return new DefineCheckExpression(identifier);
        }

        public static NegateExpression CreateNotDefined(string identifier)
        {
            return new NegateExpression(new DefineCheckExpression(identifier));
        }
    }
}