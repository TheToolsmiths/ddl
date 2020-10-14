using System;
using TheToolsmiths.Ddl.Models.Ast.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.Ast.Operators;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer.Parser.Ast.Writers
{
    public static class ConditionalExpressionWriter
    {
        public static void WriteConditionalExpression(
            IStructuredContentWriter writer,
            AstConditionalExpression conditionalExpression)
        {
            WriteConditionalExpression(writer, conditionalExpression.Root);
        }

        private static void WriteConditionalExpression(IStructuredContentWriter writer, IAstConditionalExpressionElement expression)
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

        private static void WriteSymbolExpression(IStructuredContentWriter writer, SymbolExpression expression)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "symbol");

            writer.WritePropertyName("expression");

            ConditionalSymbolExpressionWriter.WriteConditionalSymbolExpression(writer, expression.Expression);

            writer.WriteEndObject();
        }

        private static void WriteEmptyExpression(IStructuredContentWriter writer, EmptyExpression expression)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "empty");

            writer.WriteEndObject();
        }

        private static void WriteParenthesisExpression(IStructuredContentWriter writer, ParenthesisExpression expression)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "parenthesis");

            writer.WritePropertyName("inner");

            WriteConditionalExpression(writer, expression.InnerExpression);

            writer.WriteEndObject();
        }

        private static void WriteNegateExpression(IStructuredContentWriter writer, NegateExpression expression)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "negate");

            writer.WritePropertyName("inner");

            WriteConditionalExpression(writer, expression.InnerExpression);

            writer.WriteEndObject();
        }

        private static void WriteBoolLiteralExpression(IStructuredContentWriter writer, BoolLiteralExpression expression)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "literal");

            writer.WriteBoolean("value", expression.Value);

            writer.WriteEndObject();
        }

        private static void WriteBinaryExpression(IStructuredContentWriter writer, BinaryExpression expression)
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

        private static void WriteLogicalCombinedExpression(IStructuredContentWriter writer, LogicalCombinedExpressions expression)
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
