using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheToolsmiths.Ddl.Parser.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Parser.Tests.Utils
{
    public static class ConditionalExpressionsUtils
    {
        public static void AssertNotEmptyConditionalExpression(
            ConditionalExpression conditionalExpression)
        {
            Assert.IsNotNull(conditionalExpression);

            AssertElement(conditionalExpression.Root);
        }

        private static void AssertElement(IConditionalExpressionElement expression)
        {
            Assert.IsNotNull(expression);

            switch (expression)
            {
                case BinaryExpression be:
                    AssertBinaryExpression(be);
                    break;
                case NegateExpression ne:
                    AssertNegateExpression(ne);
                    break;
                case BoolLiteralExpression be:
                    AssertBoolLiteralExpression(be);
                    break;
                case SymbolExpression se:
                    AssertSymbolExpression(se);
                    break;
                case ParenthesisExpression pe:
                    AssertParenthesisExpression(pe);
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(expression));
            }
        }

        private static void AssertParenthesisExpression(ParenthesisExpression expression)
        {
            Assert.AreEqual(
                ConditionalExpressionElementType.Parenthesis,
                expression.ElementType);

            AssertElement(expression.InnerExpression);
        }

        private static void AssertSymbolExpression(SymbolExpression expression)
        {
            Assert.AreEqual(
                ConditionalExpressionElementType.Symbol,
                expression.ElementType);

            ConditionalSymbolsUtils.AssertElement(expression.Expression);
        }

        private static void AssertBoolLiteralExpression(BoolLiteralExpression expression)
        {
            Assert.AreEqual(
                ConditionalExpressionElementType.BooleanLiteral,
                expression.ElementType);
        }

        private static void AssertNegateExpression(NegateExpression expression)
        {
            Assert.AreEqual(
                ConditionalExpressionElementType.Negate,
                expression.ElementType);

            AssertElement(expression.InnerExpression);
        }

        private static void AssertBinaryExpression(BinaryExpression expression)
        {
            Assert.AreEqual(
                ConditionalExpressionElementType.Binary,
                expression.ElementType);

            AssertElement(expression.LeftExpression);

            AssertElement(expression.RightExpression);
        }
    }
}
