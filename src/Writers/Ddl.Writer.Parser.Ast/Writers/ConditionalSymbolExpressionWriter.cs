using TheToolsmiths.Ddl.Parser.Ast.Models.CompareSymbolsExpressions;
using TheToolsmiths.Ddl.Parser.Ast.Models.Operators;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer.Parser.Ast.Writers
{
    public static class ConditionalSymbolExpressionWriter
    {
        public static void WriteConditionalSymbolExpression(IStructuredContentWriter writer, IConditionalSymbolExpression expression)
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

        private static void WriteNegateSymbolExpression(IStructuredContentWriter writer, NegateSymbolExpression expression)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "negate");

            writer.WriteString("symbol", expression.Identifier.ToString());

            writer.WriteEndObject();
        }

        private static void WriteIdentifierSymbolExpression(IStructuredContentWriter writer, IdentifierSymbolExpression expression)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "identifier");

            writer.WriteString("symbol", expression.Identifier.ToString());

            writer.WriteEndObject();
        }

        private static void WriteCompareSymbolExpression(IStructuredContentWriter writer, CompareSymbolExpression expression)
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
