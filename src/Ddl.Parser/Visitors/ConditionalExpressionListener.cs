using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Parser.TokenParsers;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class ConditionalExpressionListener : DdlBaseListener
    {
        private readonly Stack<IConditionalExpressionElement> elements;

        public ConditionalExpressionListener()
        {
            elements = new Stack<IConditionalExpressionElement>();
        }

        public ConditionalExpression GetExpression()
        {
            if (elements.Count > 1)
            {
                throw new Exception();
            }

            if (elements.Count == 0)
            {
                return ConditionalExpression.CreateEmpty();
            }

            var expression = elements.Pop();

            return ConditionalExpression.Create(expression);
        }

        public override void ExitNegateExpression(DdlParser.NegateExpressionContext context)
        {
            if (elements.Count < 1)
            {
                throw new Exception();
            }

            var innerExpression = elements.Pop();

            var expression = new ParenthesisExpression(innerExpression);

            elements.Push(expression);
        }

        public override void ExitBinaryExpression(DdlParser.BinaryExpressionContext context)
        {
            var node = context.ConditionalLogicalOperator();

            var op = OperatorsParsers.ParseConditionalLogicalOperator(node);

            if (elements.Count < 2)
            {
                throw new Exception();
            }

            var right = elements.Pop();
            var left = elements.Pop();

            var expression = new BinaryExpression(op, left, right);

            elements.Push(expression);
        }

        public override void ExitParenthesisExpression(DdlParser.ParenthesisExpressionContext context)
        {
            if (elements.Count < 1)
            {
                throw new Exception();
            }

            var innerExpression = elements.Pop();

            var expression = new ParenthesisExpression(innerExpression);

            elements.Push(expression);
        }

        public override void ExitSymbolExpression(DdlParser.SymbolExpressionContext context)
        {
            var symbolExpressionContext = context.conditionalSymbolExpression();

            var visitor = new ConditionalSymbolExpressionVisitor();

            var symbols = visitor.VisitConditionalSymbolExpression(symbolExpressionContext);

            var expression = new SymbolExpression(symbols);
            elements.Push(expression);
        }

        public override void ExitBoolLiteralExpression(DdlParser.BoolLiteralExpressionContext context)
        {
            var value = LiteralParsers.ParseBooleanValue(context.BoolLiteral());

            var expression = new BoolLiteralExpression(value);

            elements.Push(expression);
        }
    }
}
