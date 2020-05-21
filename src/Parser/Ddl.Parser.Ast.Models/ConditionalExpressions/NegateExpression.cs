﻿namespace TheToolsmiths.Ddl.Parser.Ast.Models.ConditionalExpressions
{
    public class NegateExpression : IConditionalExpressionElement
    {
        public NegateExpression(IConditionalExpressionElement innerExpression)
        {
            this.InnerExpression = innerExpression;
        }

        public ConditionalExpressionElementType ElementType => ConditionalExpressionElementType.Negate;

        public IConditionalExpressionElement InnerExpression { get; }
    }
}
