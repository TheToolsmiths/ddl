using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.Compiled.Structs.Content;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer.Common.Items
{
    public class StructDefinitionContentWriter
    {
        public Result Write(ICompiledItemWriterContext context, CompiledStructContent content)
        {
            context.Writer.WriteStartObject();

            var result = this.WriteItems(context, content.Items);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            context.Writer.WriteEndObject();

            return Result.Success;
        }

        private Result WriteItems(ICompiledItemWriterContext context, IReadOnlyList<ICompiledStructItem> items)
        {
            context.Writer.WriteStartArray("items");

            foreach (var structItem in items)
            {
                var result = structItem switch
                {
                    CompiledField field => this.WriteField(context, field),
                    CompiledStructScope scope => this.WriteScope(context, scope),
                    _ => throw new ArgumentOutOfRangeException(nameof(structItem))
                };

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            context.Writer.WriteEndArray();

            return Result.Success;
        }

        private Result WriteScope(ICompiledItemWriterContext context, CompiledStructScope scope)
        {
            context.Writer.WriteStartObject();

            context.Writer.WriteString("kind", "scope");

            if (scope is ConditionalCompiledStructScope conditionalScope)
            {
                context.Writer.WritePropertyName("conditional");
                var result = context.CommonWriters.WriteConditionalExpression(conditionalScope.ConditionalExpression);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            this.WriteItems(context, scope.Items);

            context.Writer.WriteEndObject();

            return Result.Success;
        }

        private Result WriteField(ICompiledItemWriterContext context, CompiledField field)
        {
            context.Writer.WriteStartObject();

            context.Writer.WriteString("kind", "field");

            context.Writer.WriteString("name", field.Name);

            {
                context.Writer.WritePropertyName("type");
                var result = context.CommonWriters.WriteTypeUse(field.FieldType);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            {
                context.Writer.WritePropertyName("attributes");
                var result = context.CommonWriters.WriteCompiledAttributes(field.Attributes);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            {
                context.Writer.WritePropertyName("initialization");
                var result = context.CommonWriters.WriteValueInitialization(field.Initialization);

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
