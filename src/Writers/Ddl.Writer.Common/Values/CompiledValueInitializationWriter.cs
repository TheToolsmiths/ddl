using System;

using TheToolsmiths.Ddl.Models.Compiled.Values;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer.Common.Values
{
    public class CompiledValueInitializationWriter
    {
        public Result Write(ICompiledEntryWriterContext context, CompiledValueInitialization initialization)
        {
            return initialization switch
            {
                CompiledEmptyInitialization emptyInitialization => this.WriteEmptyInitialization(context, emptyInitialization),
                CompiledLiteralInitialization literalInitialization => this.WriteLiteralInitialization(context, literalInitialization),
                CompiledStructInitialization structInitialization => this.WriteStructInitialization(context, structInitialization),
                CompiledTypedStructInitialization typedStructInitialization => this.WriteTypedStructInitialization(context, typedStructInitialization),
                _ => throw new ArgumentOutOfRangeException(nameof(initialization))
            };
        }

        private Result WriteTypedStructInitialization(ICompiledEntryWriterContext context, CompiledTypedStructInitialization typedStructInitialization)
        {
            throw new NotImplementedException();
        }

        private Result WriteLiteralInitialization(ICompiledEntryWriterContext context, CompiledLiteralInitialization literalInitialization)
        {
            context.Writer.WriteStartObject();

            context.Writer.WriteString("kind", "literal");

            context.CommonWriters.WriteLiteralValue(literalInitialization.Literal);

            context.Writer.WriteEndObject();

            return Result.Success;
        }

        private Result WriteEmptyInitialization(ICompiledEntryWriterContext context, CompiledEmptyInitialization _)
        {
            context.Writer.WriteStartObject();

            context.Writer.WriteString("kind", "empty");

            context.Writer.WriteEndObject();

            return Result.Success;
        }

        public Result WriteStructInitialization(ICompiledEntryWriterContext context, CompiledStructInitialization initialization)
        {
            context.Writer.WriteStartObject();

            context.Writer.WriteString("kind", "struct");

            foreach (var field in initialization.Fields)
            {
                context.Writer.WritePropertyName(field.Name);

                var result = this.Write(context, field.Initialization);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            context.Writer.WriteEndObject();

            return Result.Success;
        }
    }
}
