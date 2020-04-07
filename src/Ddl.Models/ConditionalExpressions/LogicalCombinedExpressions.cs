using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Operators;

namespace TheToolsmiths.Ddl.Models.ConditionalExpressions
{
    public class LogicalCombinedExpressions : IConditionalExpressionElement
    {
        public LogicalCombinedExpressions(
            IConditionalLogicalOperator op,
            IReadOnlyList<IConditionalExpressionElement> expressions)
        {
            this.Op = op;
            this.Expressions = expressions;
        }

        public ConditionalExpressionElementType ElementType => ConditionalExpressionElementType.LogicalCombinedExpressions;

        public IConditionalLogicalOperator Op { get; }

        public IReadOnlyList<IConditionalExpressionElement> Expressions { get; }
    }
}
