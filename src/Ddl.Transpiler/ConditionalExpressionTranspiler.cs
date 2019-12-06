﻿using System.Text.Json;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.Operators;

namespace Ddl.Transpiler
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
    }
}
