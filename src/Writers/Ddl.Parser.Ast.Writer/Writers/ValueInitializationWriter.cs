using System;
using TheToolsmiths.Ddl.Parser.Ast.Models.Literals;
using TheToolsmiths.Ddl.Parser.Ast.Models.Values;
using TheToolsmiths.Ddl.Writer.StructuredWriters;

namespace TheToolsmiths.Ddl.Parser.Ast.Writer.Writers
{
    internal static class ValueInitializationWriter
    {
        public static void WriteValueInitialization(IStructuredWriter writer, ValueInitialization initialization)
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

        public static void WriteStructValueInitialization(IStructuredWriter writer, StructValueInitialization initialization)
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

        private static void WriteLiteralValueInitialization(IStructuredWriter writer, LiteralValueInitialization initialization)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "literal");

            string typeText = initialization.Literal switch
            {
                BoolLiteral _ => "bool",
                DefaultLiteral _ => throw new NotImplementedException(),
                EmptyLiteral _ => throw new NotImplementedException(),
                NumberLiteral _ => "number",
                StringLiteral _ => "string",
                _ => throw new ArgumentOutOfRangeException(nameof(initialization.Literal))
            };

            writer.WriteString("literalType", typeText);
            writer.WriteString("literalText", initialization.Literal.Text);

            writer.WriteEndObject();
        }

        private static void WriteTypeIdentifierInitialization(IStructuredWriter writer, TypeIdentifierInitialization initialization)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "type-identifier");

            {
                writer.WritePropertyName("typeIdentifier");

                TypeIdentifierWriter.WriteTypeIdentifier(writer, initialization.TypeIdentifier);
            }

            writer.WriteEndObject();
        }

        private static void WriteEmptyValueInitialization(IStructuredWriter writer)
        {
            writer.WriteStartObject();

            writer.WriteString("type", "empty");

            writer.WriteEndObject();
        }
    }
}
