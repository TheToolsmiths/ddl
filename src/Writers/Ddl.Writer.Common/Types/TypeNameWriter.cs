using System;
using TheToolsmiths.Ddl.Models.Types.Items;
using TheToolsmiths.Ddl.Models.Types.Names;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer.Common.Types
{
    public class TypeNameWriter
    {
        public Result Write(IRootEntryWriterContext context, ItemTypeName typeName)
        {
            context.Writer.WriteStartObject();

            this.WriteIdentifier(context, typeName.ItemName);

            context.Writer.WriteEndObject();

            return Result.Success;
        }

        private void WriteIdentifier(IRootEntryWriterContext context, TypeNameIdentifier identifier)
        {
            switch (identifier)
            {
                case GenericTypeNameIdentifier genericIdentifier:
                    this.WriteGenericIdentifier(context, genericIdentifier);
                    break;
                case SimpleTypeNameIdentifier simpleIdentifier:
                    this.WriteSimpleIdentifier(context, simpleIdentifier);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(identifier));
            }
        }

        private void WriteSimpleIdentifier(IRootEntryWriterContext context, SimpleTypeNameIdentifier identifier)
        {
            context.Writer.WriteString("name", identifier.Name);
            context.Writer.WriteString("kind", "simple");
        }

        private void WriteGenericIdentifier(IRootEntryWriterContext context, GenericTypeNameIdentifier identifier)
        {
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
        }
    }
}
