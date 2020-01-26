using System;
using System.Text.Json;
using TheToolsmiths.Ddl.Models.Types;

namespace Ddl.Transpiler
{
    public static class TypeIdentifierTranspiler
    {
        public static void WriteTypeIdentifier(Utf8JsonWriter writer, TypeIdentifier typeIdentifier)
        {
            writer.WriteStartObject();

            {
                var namespacePath = typeIdentifier.Namespace;

                if (namespacePath.IsEmpty == false)
                {
                    string namespaceValue = namespacePath.ToString();
                    writer.WriteString("namespace", namespaceValue);
                }
            }

            WriteTypeNameProperties(writer, typeIdentifier.Name);

            writer.WriteEndObject();
        }

        public static void WriteTypeName(Utf8JsonWriter writer, ITypeName typeName)
        {
            writer.WriteStartObject();

            WriteTypeNameProperties(writer, typeName);

            writer.WriteEndObject();
        }

        private static void WriteTypeNameProperties(Utf8JsonWriter writer, ITypeName typeName)
        {
            writer.WriteBoolean("isGeneric", typeName.IsGeneric);

            writer.WriteString("name", typeName.Name.ToString());

            switch (typeName)
            {
                case GenericTypeName genericTypeName:
                    WriteGenericTypeNameProperties(writer, genericTypeName);
                    break;
                case SimpleTypeName simpleTypeName:
                    WriteSimpleTypeNameProperties(writer, simpleTypeName);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(typeName));
            }
        }

        private static void WriteSimpleTypeNameProperties(Utf8JsonWriter writer, SimpleTypeName simpleTypeName)
        {
        }

        private static void WriteGenericTypeNameProperties(Utf8JsonWriter writer, GenericTypeName genericTypeName)
        {
            writer.WriteStartArray("typeArgs");

            foreach (var typeIdentifier in genericTypeName.TypeArgumentList)
            {
                WriteTypeIdentifier(writer, typeIdentifier);
            }

            writer.WriteEndArray();
        }
    }
}
