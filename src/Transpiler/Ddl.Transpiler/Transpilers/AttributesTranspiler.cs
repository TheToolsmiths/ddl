using System;
using System.Collections.Generic;
using System.Text.Json;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;

namespace TheToolsmiths.Ddl.Transpiler.Transpilers
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
                AttributeUseType.Conditional => "conditional",
                AttributeUseType.KeyedStructInitialization => "keyed-struct-init",
                _ => throw new NotImplementedException()//"unknown"
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
                case TypedStructInitializationUse typedAttributeUse:
                    WriteTypedAttributeUse(writer, typedAttributeUse);
                    break;
                case ConditionalAttributeUse conditionalAttributeUse:
                    WriteConditionalAttributeUse(writer, conditionalAttributeUse);
                    break;
                case KeyedStructInitializationAttributeUse keyedStructInitializationAttributeUse:
                    WriteKeyedStructInitializationAttributeUse(writer, keyedStructInitializationAttributeUse);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(attributeUse), attributeUse, "Attribute type is not supported");
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

        private static void WriteKeyedStructInitializationAttributeUse(Utf8JsonWriter writer, KeyedStructInitializationAttributeUse typed)
        {
            writer.WriteString("key", typed.Key.ToString());
            
            writer.WritePropertyName("value");

            ValueInitializationTranspiler.WriteStructValueInitialization(writer, typed.Initialization);
        }

        private static void WriteTypedAttributeUse(Utf8JsonWriter writer, TypedStructInitializationUse typed)
        {
            writer.WriteString("attrType", typed.Type.ToString());

            writer.WritePropertyName("value");

            ValueInitializationTranspiler.WriteStructValueInitialization(writer, typed.Initialization);
        }

        private static void WriteConditionalAttributeUse(Utf8JsonWriter writer, ConditionalAttributeUse conditional)
        {
            writer.WriteString("attrType", conditional.Type.ToString());

            writer.WritePropertyName("expression");

            ConditionalExpressionTranspiler.WriteConditionalExpression(writer, conditional.ConditionalExpression);
        }
    }
}
