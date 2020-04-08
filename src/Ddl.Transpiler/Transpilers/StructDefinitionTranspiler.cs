using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using TheToolsmiths.Ddl.Models.Structs;
using TheToolsmiths.Ddl.Models.Values;

namespace Ddl.Transpiler.Transpilers
{
    public static class StructDefinitionTranspiler
    {
        public static void WriteStructDefinition(Utf8JsonWriter writer, StructDefinition structDefinition)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "def-struct");

            {
                writer.WritePropertyName("name");

                TypeIdentifierTranspiler.WriteTypeName(writer, structDefinition.TypeName);
            }

            if (structDefinition.Attributes.Any())
            {
                writer.WritePropertyName("attributes");

                AttributesTranspiler.WriteAttributeUseArray(writer, structDefinition.Attributes);
            }

            if (structDefinition.Content.Items.Any())
            {
                writer.WritePropertyName("content");

                WriteStructDefinitionContentArray(writer, structDefinition.Content.Items);
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
