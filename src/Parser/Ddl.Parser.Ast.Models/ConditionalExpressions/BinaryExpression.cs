using TheToolsmiths.Ddl.Parser.Ast.Models.Operators;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ConditionalExpressions
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
