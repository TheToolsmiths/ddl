using System;

using TheToolsmiths.Ddl.Models.Types.Names;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer.Common.Types
{
    public class TypeNameIdentifierWriter
    {
        public Result Write(ICompiledEntryWriterContext context, TypeNameIdentifier typeName)
        {
            return typeName switch
            {
                GenericTypeNameIdentifier genericTypeName => this.WriteGenericIdentifier(context, genericTypeName),
                SimpleTypeNameIdentifier simpleTypeName => this.WriteSimpleIdentifier(context, simpleTypeName),
                _ => throw new ArgumentOutOfRangeException(nameof(typeName))
            };
        }

        private Result WriteSimpleIdentifier(ICompiledEntryWriterContext context, SimpleTypeNameIdentifier identifier)
        {
            context.Writer.WriteStartObject();

            context.Writer.WriteString("name", identifier.Name);
            context.Writer.WriteString("kind", "simple");

            context.Writer.WriteEndObject();

            return Result.Success;
        }

        private Result WriteGenericIdentifier(ICompiledEntryWriterContext context, GenericTypeNameIdentifier identifier)
        {
            context.Writer.WriteStartObject();

            context.Writer.WriteString("name", identifier.Name);
            context.Writer.WriteString("kind", "generic");

            context.Writer.WriteStartArray("parameters");

            foreach (var genericParameter in identifier.GenericParameters)
            {
                context.Writer.WriteStartObject();

                context.Writer.WriteString("name", genericParameter.Text);

                context.Writer.WriteEndObject();
            }

            context.Writer.WriteEndArray();

            context.Writer.WriteEndObject();

            return Result.Success;
        }
    }
}
