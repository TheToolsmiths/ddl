using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Ast.Operators;

namespace TheToolsmiths.Ddl.Models.Ast.ConditionalExpressions
{
    public class LogicalCombinedExpressions : IAstConditionalExpressionElement
    {
        public LogicalCombinedExpressions(
            IConditionalLogicalOperator op,
            IReadOnlyList<IAstConditionalExpressionElement> expressions)
        {
            this.Op = op;
            this.Expressions = expressions;
        }

        public AstConditionalExpressionElementType ElementType => AstConditionalExpressionElementType.LogicalCombinedExpressions;

        public IConditionalLogicalOperator Op { get; }

        public IReadOnlyList<IAstConditionalExpressionElement> Expressions { get; }
    }
}
