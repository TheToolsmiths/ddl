using System;
using TheToolsmiths.Ddl.Models.CompareSymbolsExpressions;
using TheToolsmiths.Ddl.Parser.TokenParsers;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class ConditionalSymbolExpressionListener : DdlBaseListener
    {
        private IConditionalSymbolExpression? symbolExpression;

        public IConditionalSymbolExpression GetSymbolExpression()
        {
            if (this.symbolExpression == null)
            {
                throw new Exception();
            }

            return this.symbolExpression;
        }

        public override void EnterConditionalSymbolComparison(DdlParser.ConditionalSymbolComparisonContext context)
        {
            var identifier = IdentifierParsers.CreateIdentifier(context.Identifier());

            var comparer = OperatorsParsers.ParseEqualityComparer(context.EqualityComparerOperator());

            string literalValue = LiteralParsers.ParseStringValue(context.StringLiteral());

            this.symbolExpression = new CompareSymbolExpression(identifier, comparer, literalValue);
        }

        public override void EnterIdentifierSymbol(DdlParser.IdentifierSymbolContext context)
        {
            var identifier = IdentifierParsers.CreateIdentifier(context.Identifier());

            this.symbolExpression = new IdentifierSymbolExpression(identifier);
        }

        public override void EnterConditionalSymbolNegation(DdlParser.ConditionalSymbolNegationContext context)
        {
            var identifier = IdentifierParsers.CreateIdentifier(context.Identifier());

            this.symbolExpression = new NegateSymbolExpression(identifier);
        }
    }
}
