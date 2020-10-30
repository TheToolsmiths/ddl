using System;

using TheToolsmiths.Ddl.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer.Common.ConditionalExpressions
{
    public class ConditionalExpressionsWriter
    {
        public Result Write(ICompiledEntryWriterContext context, ConditionalExpression conditional)
        {
            context.Writer.WriteStartObject();

            context.Writer.WritePropertyName("root");

            var result = this.WriteExpression(context, conditional.Root);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            context.Writer.WriteEndObject();

            return Result.Success;
        }

        private Result WriteExpression(
            ICompiledEntryWriterContext context,
            IConditionalExpressionElement expression)
        {
            return expression switch
            {
                BoolLiteralExpression boolLiteralExpression => this.WriteBoolLiteralExpression(context, boolLiteralExpression),
                DefineCheckExpression defineCheckExpression => this.WriteDefineCheck(context, defineCheckExpression),
                DefineCompareExpression defineCompareExpression => this.WriteDefineCompare(context, defineCompareExpression),
                EmptyExpression emptyExpression => this.WriteEmptyExpression(context, emptyExpression),
                LogicalExpression logicalExpression => this.WriteLogicalExpression(context, logicalExpression),
                NegateExpression negateExpression => this.WriteNegateExpression(context, negateExpression),
                _ => throw new ArgumentOutOfRangeException(nameof(expression))
            };
        }

        private Result WriteNegateExpression(ICompiledEntryWriterContext context, NegateExpression negateExpression)
        {
            context.Writer.WriteStartObject();

            context.Writer.WriteString("kind", "negate");

            context.Writer.WritePropertyName("expression");
            var result = this.WriteExpression(context, negateExpression.InnerExpression);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            context.Writer.WriteEndObject();

            return Result.Success;
        }

        private Result WriteEmptyExpression(ICompiledEntryWriterContext context, EmptyExpression emptyExpression)
        {
            context.Writer.WriteStartObject();

            context.Writer.WriteString("kind", "empty");

            context.Writer.WriteEndObject();

            return Result.Success;
        }

        private Result WriteDefineCompare(ICompiledEntryWriterContext context, DefineCompareExpression defineCompareExpression)
        {
            context.Writer.WriteStartObject();

            context.Writer.WriteString("kind", "define-compare");

            context.Writer.WriteString("define", defineCompareExpression.Define);

            context.Writer.WriteString("value", defineCompareExpression.Value);

            context.Writer.WriteEndObject();

            return Result.Success;
        }

        private Result WriteBoolLiteralExpression(ICompiledEntryWriterContext context, BoolLiteralExpression boolLiteralExpression)
        {
            context.Writer.WriteStartObject();

            context.Writer.WriteString("kind", "bool-literal");

            context.Writer.WriteBoolean("value", boolLiteralExpression.Value);

            context.Writer.WriteEndObject();

            return Result.Success;
        }

        private Result WriteDefineCheck(ICompiledEntryWriterContext context, DefineCheckExpression defineCheckExpression)
        {
            context.Writer.WriteStartObject();

            context.Writer.WriteString("kind", "define-check");

            context.Writer.WriteString("define", defineCheckExpression.Identifier);

            context.Writer.WriteEndObject();

            return Result.Success;
        }

        private Result WriteLogicalExpression(
            ICompiledEntryWriterContext context,
            LogicalExpression logicalExpression)
        {
            context.Writer.WriteStartObject();

            context.Writer.WriteString("kind", "logical");

            string operatorName = logicalExpression.Operator switch
            {
                LogicalExpressionOperator.And => "and",
                LogicalExpressionOperator.Or => "or",
                _ => throw new ArgumentOutOfRangeException()
            };

            context.Writer.WriteString("operator", operatorName);

            context.Writer.WriteStartArray("expressions");

            foreach (var expression in logicalExpression.Expressions)
            {
                var result = this.WriteExpression(context, expression);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            context.Writer.WriteEndArray();

            context.Writer.WriteEndObject();

            return Result.Success;
        }
    }
}
