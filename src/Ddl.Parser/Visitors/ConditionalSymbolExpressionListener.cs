using System;
using TheToolsmiths.Ddl.Parser.Models.CompareSymbolsExpressions;
using TheToolsmiths.Ddl.Parser.TokenParsers;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class ConditionalSymbolExpressionListener : DdlBaseListener
    {
        private IConditionalSymbolExpression? symbolExpression;

        public IConditionalSymbolExpression GetSymbolExpression()
        {
            if (symbolExpression == null)
            {
                throw new Exception();
            }

            return symbolExpression;
        }

        public override void EnterConditionalSymbolComparison(DdlParser.ConditionalSymbolComparisonContext context)
        {
            var identifier = IdentifierParsers.CreateIdentifier(context.Identifier());

            var comparer = OperatorsParsers.ParseEqualityComparer(context.EqualityComparerOperator());

            var literalValue = LiteralParsers.ParseStringValue(context.StringLiteral());

            symbolExpression = new CompareSymbolExpression(identifier, comparer, literalValue);
        }

        public override void EnterIdentifierSymbol(DdlParser.IdentifierSymbolContext context)
        {
            var identifier = IdentifierParsers.CreateIdentifier(context.Identifier());

            symbolExpression = new IdentifierSymbolExpression(identifier);
        }

        public override void EnterConditionalSymbolNegation(DdlParser.ConditionalSymbolNegationContext context)
        {
            var identifier = IdentifierParsers.CreateIdentifier(context.Identifier());

            symbolExpression = new NegateSymbolExpression(identifier);
        }
    }
}
