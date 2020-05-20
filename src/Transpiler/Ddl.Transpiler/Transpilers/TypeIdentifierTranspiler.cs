using System;
using System.Collections.Generic;
using System.Text.Json;
using TheToolsmiths.Ddl.Parser.Models.Arrays;
using TheToolsmiths.Ddl.Parser.Models.Types.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Types.Names;

namespace TheToolsmiths.Ddl.Transpiler.Transpilers
{
    public static class TypeIdentifierTranspiler
    {
        public static void WriteTypeIdentifier(Utf8JsonWriter writer, ITypeIdentifier typeIdentifier)
        {
            writer.WriteStartObject();

            WriteTypeIdentifierProperties(writer, typeIdentifier);

            writer.WriteEndObject();
        }

        private static void WriteTypeIdentifierProperties(Utf8JsonWriter writer, ITypeIdentifier typeIdentifier)
        {
            switch (typeIdentifier)
            {
                case ArrayTypeIdentifier arrayTypeIdentifier:
                    WriteArrayTypeIdentifierProperties(writer, arrayTypeIdentifier);
                    break;

                case ConstantTypeIdentifier constantTypeIdentifier:
                    WriteConstantTypeIdentifierProperties(writer, constantTypeIdentifier);
                    break;

                case QualifiedTypeIdentifier qualifiedTypeIdentifier:
                    WriteQualifiedTypeIdentifierProperties(writer, qualifiedTypeIdentifier);
                    break;

                case ReferenceTypeIdentifier referenceTypeIdentifier:
                    WriteReferenceTypeIdentifierProperties(writer, referenceTypeIdentifier);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(typeIdentifier));
            }
        }

        private static void WriteReferenceTypeIdentifierProperties(Utf8JsonWriter writer, ReferenceTypeIdentifier identifier)
        {
            writer.WriteString("type", "referenceType");

            writer.WriteStartObject("referenceType");

            WriteTypeIdentifierProperties(writer, identifier.TypeIdentifier);

            writer.WriteEndObject();
        }

        private static void WriteQualifiedTypeIdentifierProperties(Utf8JsonWriter writer, QualifiedTypeIdentifier identifier)
        {
            writer.WriteString("type", "qualifiedType");

            throw new NotImplementedException();

            //string qualifiedType = identifier.QualifiedKind switch
            //{
            //    QualifiedTypeIdentifierKind.SimpleType => "simpleType",
            //    QualifiedTypeIdentifierKind.GenericType => "genericType",
            //    _ => throw new ArgumentOutOfRangeException()
            //};

            //writer.WriteString("qualifiedType", qualifiedType);

            //var namespacePath = identifier.NamespacePath;

            //if (namespacePath.IsEmpty == false)
            //{
            //    string namespaceValue = namespacePath.ToString();
            //    writer.WriteString("namespace", namespaceValue);
            //}

            //writer.WriteBoolean("isGeneric", identifier.IsGeneric);

            //writer.WriteString("name", identifier.Name.ToString());

            //if (identifier is GenericTypeIdentifier genericTypeIdentifier)
            //{
            //    writer.WriteStartArray("typeArgs");

            //    foreach (var typeIdentifier in genericTypeIdentifier.GenericParameters)
            //    {
            //        WriteTypeIdentifier(writer, typeIdentifier);
            //    }

            //    writer.WriteEndArray();
            //}
        }

        private static void WriteArrayTypeIdentifierProperties(Utf8JsonWriter writer, ArrayTypeIdentifier identifier)
        {
            writer.WriteString("type", "arrayType");

            WriteArrayDimensions(writer, identifier.Sizes);

            writer.WriteStartObject("arrayType");

            WriteQualifiedTypeIdentifierProperties(writer, identifier.TypeIdentifier);

            writer.WriteEndObject();

        }

        private static void WriteConstantTypeIdentifierProperties(Utf8JsonWriter writer, ConstantTypeIdentifier identifier)
        {
            writer.WriteString("type", "modifierType");

            writer.WriteString("modifier-type", "const");

            writer.WriteStartObject("constType");

            WriteTypeIdentifierProperties(writer, identifier.TypeIdentifier);

            writer.WriteEndObject();

        }

        private static void WriteArrayDimensions(Utf8JsonWriter writer, IEnumerable<ArraySize> sizes)
        {
            writer.WriteStartArray("sizes");

            foreach (var size in sizes)
            {
                writer.WriteStartObject();

                switch (size)
                {
                    case DynamicArraySize _:
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

            writer.WriteBoolean("isGeneric", typeName.IsGeneric);

            writer.WriteString("name", typeName.Name.ToString());

            if (typeName is GenericTypeName genericTypeName)
            {
                writer.WriteStartArray("typeArgs");

                foreach (var identifier in genericTypeName.TypeArgumentList)
                {
                    writer.WriteStringValue(identifier.Text);
                }

                writer.WriteEndArray();
            }

            writer.WriteEndObject();
        }
    }
}
