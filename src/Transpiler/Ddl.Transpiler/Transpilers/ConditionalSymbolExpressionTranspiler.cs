using System.Text.Json;
using TheToolsmiths.Ddl.Parser.Ast.Models.CompareSymbolsExpressions;
using TheToolsmiths.Ddl.Parser.Ast.Models.Operators;

namespace TheToolsmiths.Ddl.Transpiler.Transpilers
{
    public static class ConditionalSymbolExpressionTranspiler
    {
        public static void WriteConditionalSymbolExpression(Utf8JsonWriter writer, IConditionalSymbolExpression expression)
        {
            switch (expression)
            {
                case CompareSymbolExpression compareSymbolExpression:
                    WriteCompareSymbolExpression(writer, compareSymbolExpression);
                    break;
                case IdentifierSymbolExpression identifierSymbolExpression:
                    WriteIdentifierSymbolExpression(writer, identifierSymbolExpression);
                    break;
                case NegateSymbolExpression negateSymbolExpression:
                    WriteNegateSymbolExpression(writer, negateSymbolExpression);
                    break;
            }
        }

        private static void WriteNegateSymbolExpression(Utf8JsonWriter writer, NegateSymbolExpression expression)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "negate");

            writer.WriteString("symbol", expression.Identifier.ToString());

            writer.WriteEndObject();
        }

        private static void WriteIdentifierSymbolExpression(Utf8JsonWriter writer, IdentifierSymbolExpression expression)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "identifier");

            writer.WriteString("symbol", expression.Identifier.ToString());

            writer.WriteEndObject();
        }

        private static void WriteCompareSymbolExpression(Utf8JsonWriter writer, CompareSymbolExpression expression)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "compare");

            writer.WriteString("symbol", expression.Identifier.ToString());
            writer.WriteString("value", expression.LiteralValue);


            string comparerText = expression.Comparer.EqualityComparerOperatorType switch
            {
                EqualityComparerOperatorType.Equality => "equality",
                EqualityComparerOperatorType.Inequality => "inequality",
                _ => "unknown",
            };
            writer.WriteString("comparer", comparerText);

            writer.WriteEndObject();
        }
    }
}
