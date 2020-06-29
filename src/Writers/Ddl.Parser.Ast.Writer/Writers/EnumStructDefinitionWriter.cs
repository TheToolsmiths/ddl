using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Parser.Ast.Models.Enums;
using TheToolsmiths.Ddl.Parser.Ast.Models.Structs;
using TheToolsmiths.Ddl.Parser.Ast.Models.Values;
using TheToolsmiths.Ddl.Writer.StructuredWriters;

namespace TheToolsmiths.Ddl.Parser.Ast.Writer.Writers
{
    public static class EnumStructDefinitionWriter
    {
        public static void WriteEnumStructDefinition(IStructuredWriter writer, EnumStructAstDefinition definition)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "def-enum-struct");

            {
                writer.WritePropertyName("name");

                TypeIdentifierWriter.WriteTypeName(writer, definition.TypeName);
            }

            if (definition.Attributes.Any())
            {
                writer.WritePropertyName("attributes");

                AttributesWriter.WriteAttributeUseArray(writer, definition.Attributes);
            }

            if (definition.Content.Items.Any())
            {
                writer.WritePropertyName("variants");

                WriteEnumStructDefinitionContentArray(writer, definition.Content.Items);
            }

            writer.WriteEndObject();
        }

        private static void WriteEnumStructDefinitionContentArray(
            IStructuredWriter writer,
            IEnumerable<IEnumStructDefinitionItem> contentItems)
        {
            writer.WriteStartArray();

            foreach (var item in contentItems)
            {
                WriteEnumStructDefinitionContentItem(writer, item);
            }

            writer.WriteEndArray();
        }

        private static void WriteEnumStructDefinitionContentItem(IStructuredWriter writer, IEnumStructDefinitionItem definitionItem)
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
            IStructuredWriter writer,
            IEnumerable<IStructDefinitionItem> contentItems)
        {
            writer.WriteStartArray();

            foreach (var item in contentItems)
            {
                WriteStructDefinitionContentItem(writer, item);
            }

            writer.WriteEndArray();
        }

        private static void WriteStructDefinitionContentItem(IStructuredWriter writer, IStructDefinitionItem item)
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

        private static void WriteStructScope(IStructuredWriter writer, StructScope structScope)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "def-struct-scope");

            if (structScope.ConditionalExpression.IsEmpty == false)
            {
                writer.WritePropertyName("condition");

                ConditionalExpressionWriter.WriteConditionalExpression(
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

        private static void WriteFieldDefinition(IStructuredWriter writer, FieldDefinition fieldDefinition)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "def-struct-field");

            writer.WriteString("name", fieldDefinition.Name.ToString());


            {
                writer.WritePropertyName("fieldType");

                TypeIdentifierWriter.WriteTypeIdentifier(writer, fieldDefinition.FieldType);
            }

            if (fieldDefinition.Attributes.Any())
            {
                writer.WritePropertyName("attributes");

                AttributesWriter.WriteAttributeUseArray(writer, fieldDefinition.Attributes);
            }

            if (fieldDefinition.Initialization.Type != ValueInitializationType.Empty)
            {
                writer.WritePropertyName("initialization");

                ValueInitializationWriter.WriteValueInitialization(writer, fieldDefinition.Initialization);
            }

            writer.WriteEndObject();
        }
    }
}
