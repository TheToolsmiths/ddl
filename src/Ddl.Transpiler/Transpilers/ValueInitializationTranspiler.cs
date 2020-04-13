using System;
using System.Text.Json;
using TheToolsmiths.Ddl.Models.Literals;
using TheToolsmiths.Ddl.Models.Values;

namespace Ddl.Transpiler.Transpilers
{
    internal static class ValueInitializationTranspiler
    {
        public static void WriteValueInitialization(Utf8JsonWriter writer, ValueInitialization initialization)
        {
            switch (initialization)
            {
                case EmptyValueInitialization _:
                    WriteEmptyValueInitialization(writer);
                    break;

                case LiteralValueInitialization literalValue:
                    WriteLiteralValueInitialization(writer, literalValue);
                    break;

                case StructValueInitialization structValue:
                    WriteStructValueInitialization(writer, structValue);
                    break;

                case TypeIdentifierInitialization typeIdentifier:
                    WriteTypeIdentifierInitialization(writer, typeIdentifier);
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        public static void WriteStructValueInitialization(Utf8JsonWriter writer, StructValueInitialization initialization)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "struct");

            foreach (var field in initialization.Fields)
            {
                writer.WritePropertyName(field.Name.ToString());

                WriteValueInitialization(writer, field.Initialization);
            }

            writer.WriteEndObject();
        }

        private static void WriteLiteralValueInitialization(Utf8JsonWriter writer, LiteralValueInitialization literalValue)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "literal");

            var literal = literalValue.Literal;

            string typeText = literal.ValueType switch
            {
                LiteralValueType.StringLiteral => "string",
                LiteralValueType.NumberLiteral => "number",
                LiteralValueType.BooleanLiteral => "bool",
                _ => "string"
            };

            writer.WriteString("literalType", typeText);
            writer.WriteString("literalText", literal.Text);

            writer.WriteEndObject();
        }

        private static void WriteTypeIdentifierInitialization(Utf8JsonWriter writer, TypeIdentifierInitialization initialization)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "type-identifier");

            {
                writer.WritePropertyName("typeIdentifier");

                TypeIdentifierTranspiler.WriteTypeIdentifier(writer, initialization.TypeIdentifier);
            }

            writer.WriteEndObject();
        }

        private static void WriteEmptyValueInitialization(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "empty");

            writer.WriteEndObject();
        }
    }
}
