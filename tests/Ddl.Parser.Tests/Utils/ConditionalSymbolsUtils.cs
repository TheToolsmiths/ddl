using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheToolsmiths.Ddl.Models.CompareSymbolsExpressions;

namespace TheToolsmiths.Ddl.Parser.Tests.Utils
{
    internal static class ConditionalSymbolsUtils
    {
        public static void AssertElement(IConditionalSymbolExpression expression)
        {
            Assert.IsNotNull(expression);

            switch (expression)
            {
                case CompareSymbolExpression ce:
                    AssertCompareExpression(ce);
                    break;
                case IdentifierSymbolExpression se:
                    AssertIdentifierExpression(se);
                    break;
                case NegateSymbolExpression ne:
                    AssertNegateExpression(ne);
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(expression));
            }
        }

        private static void AssertCompareExpression(CompareSymbolExpression expression)
        {
            Assert.AreEqual(
                ConditionalSymbolExpressionType.Compare,
                expression.SymbolExpressionType);

            Assert.IsNotNull(expression.Identifier);

            Assert.IsNotNull(expression.LiteralValue);
        }

        private static void AssertNegateExpression(NegateSymbolExpression expression)
        {
            Assert.AreEqual(
                ConditionalSymbolExpressionType.Negate,
                expression.SymbolExpressionType);

            Assert.IsNotNull(expression.Identifier);
        }

        private static void AssertIdentifierExpression(IdentifierSymbolExpression expression)
        {
            Assert.AreEqual(
                ConditionalSymbolExpressionType.Identifier,
                expression.SymbolExpressionType);

            Assert.IsNotNull(expression.Identifier);
        }
    }
}
