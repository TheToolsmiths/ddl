using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.Compiled.ConditionalExpressions
{
    public class LogicalExpression : IConditionalExpressionElement
    {
        private LogicalExpression(LogicalExpressionOperator op, IReadOnlyList<IConditionalExpressionElement> expressions)
        {
            this.Op = op;
            this.Expressions = expressions;
        }

        public LogicalExpressionOperator Op { get; }

        public IReadOnlyList<IConditionalExpressionElement> Expressions { get; }

        public ConditionalExpressionElementType ElementType => ConditionalExpressionElementType.Logical;

        public static IConditionalExpressionElement CreateAnd(IReadOnlyList<IConditionalExpressionElement> expressions)
        {
            return new LogicalExpression(LogicalExpressionOperator.And, expressions);
        }

        public static IConditionalExpressionElement CreateAnd(params IConditionalExpressionElement[] expressions)
        {
            return new LogicalExpression(LogicalExpressionOperator.And, expressions);
        }

        public static IConditionalExpressionElement CreateOr(IReadOnlyList<IConditionalExpressionElement> expressions)
        {
            return new LogicalExpression(LogicalExpressionOperator.Or, expressions);
        }

        public static IConditionalExpressionElement CreateOr(params IConditionalExpressionElement[] expressions)
        {
            return new LogicalExpression(LogicalExpressionOperator.Or, expressions);
        }
    }
}
