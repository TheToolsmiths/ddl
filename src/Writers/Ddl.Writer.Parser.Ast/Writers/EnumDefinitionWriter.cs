using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Parser.Ast.Models.Enums;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer.Parser.Ast.Writers
{
    public static class EnumDefinitionWriter
    {
        public static void WriteEnumDefinition(IStructuredContentWriter writer, EnumAstDefinition definition)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "def-enum");

            {
                writer.WritePropertyName("name");

                TypeIdentifierWriter.WriteTypeName(writer, definition.TypeName);
            }

            if (definition.Attributes.HasAttributes)
            {
                writer.WritePropertyName("attributes");

                AttributesWriter.WriteAttributeUseArray(writer, definition.Attributes);
            }

            if (definition.Content.Items.Any())
            {
                writer.WritePropertyName("constants");

                WriteEnumStructDefinitionContentArray(writer, definition.Content.Items);
            }

            writer.WriteEndObject();
        }

        private static void WriteEnumStructDefinitionContentArray(
            IStructuredContentWriter writer,
            IEnumerable<IEnumDefinitionItem> contentItems)
        {
            writer.WriteStartArray();

            foreach (var item in contentItems)
            {
                WriteEnumStructDefinitionContentItem(writer, item);
            }

            writer.WriteEndArray();
        }

        private static void WriteEnumStructDefinitionContentItem(IStructuredContentWriter writer, IEnumDefinitionItem definitionItem)
        {
            writer.WriteStartObject();

            switch (definitionItem)
            {
                case EnumDefinitionConstantDefinition constant:

                    writer.WriteString("name", constant.Name.ToString());

                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(definitionItem));
            }

            writer.WriteEndObject();
        }
    }
}
