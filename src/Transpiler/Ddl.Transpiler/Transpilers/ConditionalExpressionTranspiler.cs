using System;
using System.Text.Json;
using TheToolsmiths.Ddl.Parser.Ast.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Parser.Ast.Models.Operators;

namespace TheToolsmiths.Ddl.Transpiler.Transpilers
{
    public static class ConditionalExpressionTranspiler
    {
        public static void WriteConditionalExpression(
            Utf8JsonWriter writer,
            ConditionalExpression conditionalExpression)
        {
            WriteConditionalExpression(writer, conditionalExpression.Root);
        }

        private static void WriteConditionalExpression(Utf8JsonWriter writer, IConditionalExpressionElement expression)
        {
            switch (expression)
            {
                case BinaryExpression binaryExpression:
                    WriteBinaryExpression(writer, binaryExpression);
                    break;
                case LogicalCombinedExpressions logicalCombinedExpressions:
                    WriteLogicalCombinedExpression(writer, logicalCombinedExpressions);
                    break;
                case BoolLiteralExpression boolLiteralExpression:
                    WriteBoolLiteralExpression(writer, boolLiteralExpression);
                    break;
                case NegateExpression negateExpression:
                    WriteNegateExpression(writer, negateExpression);
                    break;
                case ParenthesisExpression parenthesisExpression:
                    WriteParenthesisExpression(writer, parenthesisExpression);
                    break;
                case SymbolExpression symbolExpression:
                    WriteSymbolExpression(writer, symbolExpression);
                    break;

                case EmptyExpression emptyExpression:
                    WriteEmptyExpression(writer, emptyExpression);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(expression));
            }
        }

        private static void WriteSymbolExpression(Utf8JsonWriter writer, SymbolExpression expression)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "symbol");

            writer.WritePropertyName("expression");

            ConditionalSymbolExpressionTranspiler.WriteConditionalSymbolExpression(writer, expression.Expression);

            writer.WriteEndObject();
        }

        private static void WriteEmptyExpression(Utf8JsonWriter writer, EmptyExpression expression)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "empty");

            writer.WriteEndObject();
        }

        private static void WriteParenthesisExpression(Utf8JsonWriter writer, ParenthesisExpression expression)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "parenthesis");

            writer.WritePropertyName("inner");

            WriteConditionalExpression(writer, expression.InnerExpression);

            writer.WriteEndObject();
        }

        private static void WriteNegateExpression(Utf8JsonWriter writer, NegateExpression expression)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "negate");

            writer.WritePropertyName("inner");

            WriteConditionalExpression(writer, expression.InnerExpression);

            writer.WriteEndObject();
        }

        private static void WriteBoolLiteralExpression(Utf8JsonWriter writer, BoolLiteralExpression expression)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "literal");

            writer.WriteBoolean("value", expression.Value);

            writer.WriteEndObject();
        }

        private static void WriteBinaryExpression(Utf8JsonWriter writer, BinaryExpression expression)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "binary");

            string opText = expression.Op.LogicalOperatorType switch
            {
                ConditionalLogicalOperatorType.And => "and",
                ConditionalLogicalOperatorType.Or => "or",
                _ => "unknown",
            };

            writer.WriteString("op", opText);

            writer.WritePropertyName("left");
            WriteConditionalExpression(writer, expression.LeftExpression);

            writer.WritePropertyName("right");
            WriteConditionalExpression(writer, expression.RightExpression);

            writer.WriteEndObject();
        }

        private static void WriteLogicalCombinedExpression(Utf8JsonWriter writer, LogicalCombinedExpressions expression)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "logic-combined");

            string opText = expression.Op.LogicalOperatorType switch
            {
                ConditionalLogicalOperatorType.And => "and",
                ConditionalLogicalOperatorType.Or => "or",
                _ => "unknown",
            };

            writer.WriteString("op", opText);

            writer.WriteStartArray("expressions");

            foreach (var element in expression.Expressions)
            {
                WriteConditionalExpression(writer, element);
            }

            writer.WriteEndArray();

            writer.WriteEndObject();
        }
    }
}
