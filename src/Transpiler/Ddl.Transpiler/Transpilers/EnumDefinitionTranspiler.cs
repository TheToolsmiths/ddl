using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using TheToolsmiths.Ddl.Parser.Models.Enums;

namespace TheToolsmiths.Ddl.Transpiler.Transpilers
{
    public static class EnumDefinitionTranspiler
    {
        public static void WriteEnumDefinition(Utf8JsonWriter writer, EnumDefinition definition)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "def-enum");

            {
                writer.WritePropertyName("name");

                TypeIdentifierTranspiler.WriteTypeName(writer, definition.TypeName);
            }

            if (definition.Attributes.Any())
            {
                writer.WritePropertyName("attributes");

                AttributesTranspiler.WriteAttributeUseArray(writer, definition.Attributes);
            }

            if (definition.Content.Items.Any())
            {
                writer.WritePropertyName("constants");

                WriteEnumStructDefinitionContentArray(writer, definition.Content.Items);
            }

            writer.WriteEndObject();
        }

        private static void WriteEnumStructDefinitionContentArray(
            Utf8JsonWriter writer,
            IEnumerable<IEnumDefinitionItem> contentItems)
        {
            writer.WriteStartArray();

            foreach (var item in contentItems)
            {
                WriteEnumStructDefinitionContentItem(writer, item);
            }

            writer.WriteEndArray();
        }

        private static void WriteEnumStructDefinitionContentItem(Utf8JsonWriter writer, IEnumDefinitionItem definitionItem)
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
