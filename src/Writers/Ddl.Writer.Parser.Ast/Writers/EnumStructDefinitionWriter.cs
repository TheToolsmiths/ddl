﻿using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.Ast.Enums;
using TheToolsmiths.Ddl.Models.Ast.Structs;
using TheToolsmiths.Ddl.Models.Ast.Values;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer.Parser.Ast.Writers
{
    public static class EnumStructDefinitionWriter
    {
        public static void WriteEnumStructDefinition(IStructuredContentWriter writer, EnumStructAstDefinition definition)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "def-enum-struct");

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
                writer.WritePropertyName("variants");

                WriteEnumStructDefinitionContentArray(writer, definition.Content.Items);
            }

            writer.WriteEndObject();
        }

        private static void WriteEnumStructDefinitionContentArray(
            IStructuredContentWriter writer,
            IEnumerable<IEnumStructDefinitionItem> contentItems)
        {
            writer.WriteStartArray();

            foreach (var item in contentItems)
            {
                WriteEnumStructDefinitionContentItem(writer, item);
            }

            writer.WriteEndArray();
        }

        private static void WriteEnumStructDefinitionContentItem(IStructuredContentWriter writer, IEnumStructDefinitionItem definitionItem)
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
            IStructuredContentWriter writer,
            IEnumerable<IStructDefinitionItem> contentItems)
        {
            writer.WriteStartArray();

            foreach (var item in contentItems)
            {
                WriteStructDefinitionContentItem(writer, item);
            }

            writer.WriteEndArray();
        }

        private static void WriteStructDefinitionContentItem(IStructuredContentWriter writer, IStructDefinitionItem item)
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

        private static void WriteStructScope(IStructuredContentWriter writer, StructScope structScope)
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

        private static void WriteFieldDefinition(IStructuredContentWriter writer, FieldDefinition fieldDefinition)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "def-struct-field");

            writer.WriteString("name", fieldDefinition.Name.ToString());


            {
                writer.WritePropertyName("fieldType");

                TypeIdentifierWriter.WriteTypeIdentifier(writer, fieldDefinition.FieldType);
            }

            if (fieldDefinition.Attributes.HasAttributes)
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