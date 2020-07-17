using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Ast.Models.Operators;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ConditionalExpressions
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
