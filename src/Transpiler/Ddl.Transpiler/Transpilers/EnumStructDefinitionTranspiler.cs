using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using TheToolsmiths.Ddl.Parser.Models.Enums;
using TheToolsmiths.Ddl.Parser.Models.Structs;
using TheToolsmiths.Ddl.Parser.Models.Values;

namespace TheToolsmiths.Ddl.Transpiler.Transpilers
{
    public static class EnumStructDefinitionTranspiler
    {
        public static void WriteEnumStructDefinition(Utf8JsonWriter writer, EnumStructDefinition definition)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "def-enum-struct");

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
                writer.WritePropertyName("variants");

                WriteEnumStructDefinitionContentArray(writer, definition.Content.Items);
            }

            writer.WriteEndObject();
        }

        private static void WriteEnumStructDefinitionContentArray(
            Utf8JsonWriter writer,
            IEnumerable<IEnumStructDefinitionItem> contentItems)
        {
            writer.WriteStartArray();

            foreach (var item in contentItems)
            {
                WriteEnumStructDefinitionContentItem(writer, item);
            }

            writer.WriteEndArray();
        }

        private static void WriteEnumStructDefinitionContentItem(Utf8JsonWriter writer, IEnumStructDefinitionItem definitionItem)
        {
            writer.WriteStartObject();

            switch (definitionItem)
            {
                case EnumStructVariantDefinition variant:

                    writer.WriteString("name", variant.Name.ToString());

                    writer.WritePropertyName("content");

                    WriteStructDefinitionContentArray(writer, variant.Content.Items);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(definitionItem));
            }

            writer.WriteEndObject();
        }

        private static void WriteStructDefinitionContentArray(
            Utf8JsonWriter writer,
            IEnumerable<IStructDefinitionItem> contentItems)
        {
            writer.WriteStartArray();

            foreach (var item in contentItems)
            {
                WriteStructDefinitionContentItem(writer, item);
            }

            writer.WriteEndArray();
        }

        private static void WriteStructDefinitionContentItem(Utf8JsonWriter writer, IStructDefinitionItem item)
        {
            switch (item)
            {
                case FieldDefinition fieldDefinition:
                    WriteFieldDefinition(writer, fieldDefinition);
                    break;
                case StructScope structScope:
                    WriteStructScope(writer, structScope);
                    break;
            }
        }

        private static void WriteStructScope(Utf8JsonWriter writer, StructScope structScope)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "def-struct-scope");

            if (structScope.ConditionalExpression.IsEmpty == false)
            {
                writer.WritePropertyName("condition");

                ConditionalExpressionTranspiler.WriteConditionalExpression(
                    writer,
                    structScope.ConditionalExpression);
            }

            if (structScope.Content.Items.Any())
            {
                writer.WritePropertyName("content");

                WriteStructDefinitionContentArray(writer, structScope.Content.Items);
            }

            writer.WriteEndObject();
        }

        private static void WriteFieldDefinition(Utf8JsonWriter writer, FieldDefinition fieldDefinition)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "def-struct-field");

            writer.WriteString("name", fieldDefinition.Name.ToString());


            {
                writer.WritePropertyName("fieldType");

                TypeIdentifierTranspiler.WriteTypeIdentifier(writer, fieldDefinition.FieldType);
            }

            if (fieldDefinition.Attributes.Any())
            {
                writer.WritePropertyName("attributes");

                AttributesTranspiler.WriteAttributeUseArray(writer, fieldDefinition.Attributes);
            }

            if (fieldDefinition.Initialization.Type != ValueInitializationType.Empty)
            {
                writer.WritePropertyName("initialization");

                ValueInitializationTranspiler.WriteValueInitialization(writer, fieldDefinition.Initialization);
            }

            writer.WriteEndObject();
        }
    }
}
