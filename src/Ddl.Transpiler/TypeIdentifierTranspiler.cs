using System;
using System.Collections.Generic;
using System.Text.Json;
using TheToolsmiths.Ddl.Models.Arrays;
using TheToolsmiths.Ddl.Models.Types;

namespace Ddl.Transpiler
{
    public static class TypeIdentifierTranspiler
    {
        public static void WriteTypeIdentifier(Utf8JsonWriter writer, ITypeIdentifier typeIdentifier)
        {
            writer.WriteStartObject();

            switch (typeIdentifier)
            {
                case ArrayTypeIdentifier arrayTypeIdentifier:
                    WriteArrayTypeIdentifierProperties(writer, arrayTypeIdentifier);
                    break;
                case QualifiedTypeIdentifier qualifiedTypeIdentifier:
                    WriteQualifiedTypeIdentifierProperties(writer, qualifiedTypeIdentifier);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(typeIdentifier));
            }

            writer.WriteEndObject();
        }

        private static void WriteQualifiedTypeIdentifierProperties(Utf8JsonWriter writer, QualifiedTypeIdentifier identifier)
        {
            writer.WriteString("type", "qualifiedType");

            var namespacePath = identifier.Namespace;

            if (namespacePath.IsEmpty == false)
            {
                string namespaceValue = namespacePath.ToString();
                writer.WriteString("namespace", namespaceValue);
            }


            WriteTypeNameProperties(writer, identifier.Name);
        }

        private static void WriteArrayTypeIdentifierProperties(Utf8JsonWriter writer, ArrayTypeIdentifier identifier)
        {
            writer.WriteString("type", "arrayType");

            WriteArrayDimensions(writer, identifier.Sizes);

            writer.WriteStartObject("arrayType");

            WriteQualifiedTypeIdentifierProperties(writer, identifier.TypeIdentifier);

            writer.WriteEndObject();

        }

        private static void WriteArrayDimensions(Utf8JsonWriter writer, IReadOnlyList<ArraySize> sizes)
        {
            writer.WriteStartArray("sizes");

            foreach (var size in sizes)
            {
                writer.WriteStartObject();

                switch (size)
                {
                    case DynamicArraySize dynamicSize:
                        writer.WriteString("type", "dynamic");
                        break;

                    case FixedArraySize fixedSize:
                        writer.WriteString("type", "fixed");

                        writer.WriteStartArray("dimensions");
                        foreach (string dimension in fixedSize.Dimensions)
                        {
                            writer.WriteStringValue(dimension);
                        }

                        writer.WriteEndArray();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(size));
                }


                writer.WriteEndObject();
            }

            writer.WriteEndArray();
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
                case SimpleTypeName _:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(typeName));
            }
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
