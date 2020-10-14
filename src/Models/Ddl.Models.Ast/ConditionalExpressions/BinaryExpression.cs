using TheToolsmiths.Ddl.Models.Ast.Operators;

namespace TheToolsmiths.Ddl.Models.Ast.ConditionalExpressions
{
    public class BinaryExpression : IAstConditionalExpressionElement
    {
        public BinaryExpression(
            IConditionalLogicalOperator op,
            IAstConditionalExpressionElement leftExpression,
            IAstConditionalExpressionElement rightExpression)
        {
            this.Op = op;
            this.LeftExpression = leftExpression;
            this.RightExpression = rightExpression;
        }

        public AstConditionalExpressionElementType ElementType => AstConditionalExpressionElementType.Binary;

        public IConditionalLogicalOperator Op { get; }

        public IAstConditionalExpressionElement LeftExpression { get; }

        public IAstConditionalExpressionElement RightExpression { get; }
    }
}
