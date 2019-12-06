﻿using TheToolsmiths.Ddl.Models.CompareSymbolsExpressions;

namespace TheToolsmiths.Ddl.Models.ConditionalExpressions
{
    public class SymbolExpression : IConditionalExpressionElement
    {
        public SymbolExpression(IConditionalSymbolExpression expression)
        {
            this.Expression = expression;
        }

        public ConditionalExpressionElementType ElementType => ConditionalExpressionElementType.Symbol;

        public IConditionalSymbolExpression Expression { get; }
    }
}
