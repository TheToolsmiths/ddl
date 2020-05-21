using TheToolsmiths.Ddl.Parser.Ast.Models.Operators;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ConditionalExpressions
{
    public class BinaryExpression : IConditionalExpressionElement
    {
        public BinaryExpression(
            IConditionalLogicalOperator op,
            IConditionalExpressionElement leftExpression,
            IConditionalExpressionElement rightExpression)
        {
            this.Op = op;
            this.LeftExpression = leftExpression;
            this.RightExpression = rightExpression;
        }

        public ConditionalExpressionElementType ElementType => ConditionalExpressionElementType.Binary;

        public IConditionalLogicalOperator Op { get; }

        public IConditionalExpressionElement LeftExpression { get; }

        public IConditionalExpressionElement RightExpression { get; }
    }
}
