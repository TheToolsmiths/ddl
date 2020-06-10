using System;
using System.Collections.Generic;
using System.Text.Json;
using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;

namespace TheToolsmiths.Ddl.Transpiler.Transpilers
{
    public static class AttributesTranspiler
    {
        public static void WriteAttributeUseArray(Utf8JsonWriter writer, IEnumerable<IAstAttributeUse> attributes)
        {
            writer.WriteStartArray();

            foreach (var attributeUse in attributes)
            {
                WriteAttributeUse(writer, attributeUse);
            }

            writer.WriteEndArray();
        }

        private static void WriteAttributeUse(Utf8JsonWriter writer, IAstAttributeUse attributeUse)
        {
            writer.WriteStartObject();

            string useType = attributeUse.UseKind switch
            {
                AttributeUseKind.KeyedLiteral => "keyed-literal",
                AttributeUseKind.KeyedTyped => "keyed-typed",
                AttributeUseKind.Typed => "typed",
                AttributeUseKind.Conditional => "conditional",
                AttributeUseKind.KeyedStructInitialization => "keyed-struct-init",
                _ => throw new NotImplementedException()//"unknown"
            };

            writer.WriteString("type", useType);

            switch (attributeUse)
            {
                case KeyedLiteralAstAttributeUse keyedLiteralAttributeUse:
                    WriteKeyedLiteralAttributeUse(writer, keyedLiteralAttributeUse);
                    break;
                case KeyedTypedAstAttributeUse keyedTypedAttributeUse:
                    WriteKeyedTypedAttributeUse(writer, keyedTypedAttributeUse);
                    break;
                case AstTypedStructInitializationUse typedAttributeUse:
                    WriteTypedAttributeUse(writer, typedAttributeUse);
                    break;
                case ConditionalAstAttributeUse conditionalAttributeUse:
                    WriteConditionalAttributeUse(writer, conditionalAttributeUse);
                    break;
                case KeyedStructInitializationAstAttributeUse keyedStructInitializationAttributeUse:
                    WriteKeyedStructInitializationAttributeUse(writer, keyedStructInitializationAttributeUse);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(attributeUse), attributeUse, "Attribute type is not supported");
            }

            writer.WriteEndObject();
        }

        private static void WriteKeyedLiteralAttributeUse(Utf8JsonWriter writer, KeyedLiteralAstAttributeUse keyedLiteral)
        {
            writer.WriteString("key", keyedLiteral.Key.ToString());

            writer.WriteString("value", keyedLiteral.Literal.ToString());
        }

        private static void WriteKeyedTypedAttributeUse(Utf8JsonWriter writer, KeyedTypedAstAttributeUse keyedTyped)
        {
            writer.WriteString("key", keyedTyped.Key.ToString());

            writer.WriteString("attrType", keyedTyped.Type.ToString());

            writer.WritePropertyName("value");

            ValueInitializationTranspiler.WriteStructValueInitialization(writer, keyedTyped.Initialization);
        }

        private static void WriteKeyedStructInitializationAttributeUse(Utf8JsonWriter writer, KeyedStructInitializationAstAttributeUse typed)
        {
            writer.WriteString("key", typed.Key.ToString());
            
            writer.WritePropertyName("value");

            ValueInitializationTranspiler.WriteStructValueInitialization(writer, typed.Initialization);
        }

        private static void WriteTypedAttributeUse(Utf8JsonWriter writer, AstTypedStructInitializationUse typed)
        {
            writer.WriteString("attrType", typed.Type.ToString());

            writer.WritePropertyName("value");

            ValueInitializationTranspiler.WriteStructValueInitialization(writer, typed.Initialization);
        }

        private static void WriteConditionalAttributeUse(Utf8JsonWriter writer, ConditionalAstAttributeUse conditional)
        {
            writer.WriteString("attrType", conditional.Type.ToString());

            writer.WritePropertyName("expression");

            ConditionalExpressionTranspiler.WriteConditionalExpression(writer, conditional.ConditionalExpression);
        }
    }
}
