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
            this.elements = new Stack<IConditionalExpressionElement>();
        }

        public ConditionalExpression GetExpression()
        {
            if (this.elements.Count > 1)
            {
                throw new Exception();
            }

            if (this.elements.Count == 0)
            {
                return ConditionalExpression.CreateEmpty();
            }

            var expression = this.elements.Pop();

            return ConditionalExpression.Create(expression);
        }

        public override void ExitNegateExpression(DdlParser.NegateExpressionContext context)
        {
            if (this.elements.Count < 1)
            {
                throw new Exception();
            }

            var innerExpression = this.elements.Pop();

            var expression = new NegateExpression(innerExpression);

            this.elements.Push(expression);
        }

        public override void ExitBinaryExpression(DdlParser.BinaryExpressionContext context)
        {
            var node = context.ConditionalLogicalOperator();

            var op = OperatorsParsers.ParseConditionalLogicalOperator(node);

            if (this.elements.Count < 2)
            {
                throw new Exception();
            }

            var right = this.elements.Pop();
            var left = this.elements.Pop();

            var expression = new BinaryExpression(op, left, right);

            this.elements.Push(expression);
        }

        public override void ExitParenthesisExpression(DdlParser.ParenthesisExpressionContext context)
        {
            if (this.elements.Count < 1)
            {
                throw new Exception();
            }

            var innerExpression = this.elements.Pop();

            var expression = new ParenthesisExpression(innerExpression);

            this.elements.Push(expression);
        }

        public override void ExitSymbolExpression(DdlParser.SymbolExpressionContext context)
        {
            var symbolExpressionContext = context.conditionalSymbolExpression();

            var visitor = new ConditionalSymbolExpressionVisitor();

            var symbols = visitor.VisitConditionalSymbolExpression(symbolExpressionContext);

            var expression = new SymbolExpression(symbols);
            this.elements.Push(expression);
        }

        public override void ExitBoolLiteralExpression(DdlParser.BoolLiteralExpressionContext context)
        {
            bool value = LiteralParsers.ParseBooleanValue(context.BoolLiteral());

            var expression = new BoolLiteralExpression(value);

            this.elements.Push(expression);
        }
    }
}
