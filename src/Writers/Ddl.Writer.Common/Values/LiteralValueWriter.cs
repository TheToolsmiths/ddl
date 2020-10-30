using System;

using TheToolsmiths.Ddl.Models.Literals;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer.Common.Values
{
    public class LiteralValueWriter
    {
        public Result Write(ICompiledEntryWriterContext context, LiteralValue literalValue)
        {
            return literalValue switch
            {
                BoolLiteral boolLiteral => this.WriteBool(context, boolLiteral),
                DefaultLiteral defaultLiteral => this.WriteDefault(context, defaultLiteral),
                NumberLiteral numberLiteral => this.WriteNumber(context, numberLiteral),
                StringLiteral stringLiteral => this.WriteString(context, stringLiteral),
                _ => throw new ArgumentOutOfRangeException(nameof(literalValue))
            };
        }

        private Result WriteString(ICompiledEntryWriterContext context, StringLiteral stringLiteral)
        {
            context.Writer.WriteString("value-kind", "string");

            context.Writer.WriteString("value", stringLiteral.Text);

            return Result.Success;
        }

        private Result WriteNumber(ICompiledEntryWriterContext context, NumberLiteral numberLiteral)
        {
            context.Writer.WriteString("value-kind", "number");

            context.Writer.WriteString("value", numberLiteral.ToString());

            return Result.Success;
        }

        private Result WriteDefault(ICompiledEntryWriterContext context, DefaultLiteral defaultLiteral)
        {
            context.Writer.WriteString("value-kind", "default");

            return Result.Success;
        }

        private Result WriteBool(ICompiledEntryWriterContext context, BoolLiteral boolLiteral)
        {
            context.Writer.WriteString("value-kind", "bool");

            context.Writer.WriteBoolean("value", boolLiteral.Value);

            return Result.Success;
        }
    }
}
