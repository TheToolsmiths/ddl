using System;
using System.Collections.Generic;
using System.Text.Json;
using TheToolsmiths.Ddl.Models.AttributeUsage;

namespace Ddl.Transpiler
{
    public static class AttributesTranspiler
    {
        public static void WriteAttributeUseArray(Utf8JsonWriter writer, IEnumerable<IAttributeUse> attributes)
        {
            writer.WriteStartArray();

            foreach (var attributeUse in attributes)
            {
                WriteAttributeUse(writer, attributeUse);
            }

            writer.WriteEndArray();
        }

        private static void WriteAttributeUse(Utf8JsonWriter writer, IAttributeUse attributeUse)
        {
            writer.WriteStartObject();

            string useType = attributeUse.UseType switch
            {
                AttributeUseType.KeyedLiteral => "keyed-literal",
                AttributeUseType.KeyedTyped => "keyed-typed",
                AttributeUseType.Typed => "typed",
                _ => "unknown"
            };

            writer.WriteString("type", useType);

            switch (attributeUse)
            {
                case KeyedLiteralAttributeUse keyedLiteralAttributeUse:
                    WriteKeyedLiteralAttributeUse(writer, keyedLiteralAttributeUse);
                    break;
                case KeyedTypedAttributeUse keyedTypedAttributeUse:
                    WriteKeyedTypedAttributeUse(writer, keyedTypedAttributeUse);
                    break;
                case TypedAttributeUse typedAttributeUse:
                    WriteTypedAttributeUse(writer, typedAttributeUse);
                    break;
            }

            writer.WriteEndObject();
        }

        private static void WriteKeyedLiteralAttributeUse(Utf8JsonWriter writer, KeyedLiteralAttributeUse keyedLiteral)
        {
            writer.WriteString("key", keyedLiteral.Key.ToString());

            writer.WriteString("value", keyedLiteral.Literal.ToString());
        }

        private static void WriteKeyedTypedAttributeUse(Utf8JsonWriter writer, KeyedTypedAttributeUse keyedTyped)
        {
            writer.WriteString("key", keyedTyped.Key.ToString());

            writer.WriteString("attrType", keyedTyped.Type.ToString());

            writer.WritePropertyName("value");

            ValueInitializationTranspiler.WriteStructValueInitialization(writer, keyedTyped.Initialization);
        }

        private static void WriteTypedAttributeUse(Utf8JsonWriter writer, TypedAttributeUse typed)
        {
            writer.WriteString("attrType", typed.Type.ToString());

            writer.WritePropertyName("value");

            ValueInitializationTranspiler.WriteStructValueInitialization(writer, typed.Initialization);
        }
    }
}
