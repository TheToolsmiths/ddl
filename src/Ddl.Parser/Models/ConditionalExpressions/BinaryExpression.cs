using TheToolsmiths.Ddl.Parser.Models.Operators;

namespace TheToolsmiths.Ddl.Parser.Models.ConditionalExpressions
{
    public class BinaryExpression : IConditionalExpressionElement
    {
        public BinaryExpression(
            IConditionalLogicalOperator op,
            IConditionalExpressionElement leftExpression,
            IConditionalExpressionElement rightExpression)
        {
            Op = op;
            LeftExpression = leftExpression;
            RightExpression = rightExpression;
        }
        
        public ConditionalExpressionElementType ElementType => ConditionalExpressionElementType.Binary;

        public IConditionalLogicalOperator Op { get; }

        public IConditionalExpressionElement LeftExpression { get; }

        public IConditionalExpressionElement RightExpression { get; }
    }
}
