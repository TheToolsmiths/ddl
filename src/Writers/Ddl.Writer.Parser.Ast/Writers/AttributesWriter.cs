using System;
using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer.Parser.Ast.Writers
{
    public static class AttributesWriter
    {
        public static void WriteAttributeUseArray(IStructuredContentWriter writer, AstAttributeUseCollection attributes)
        {
            writer.WriteStartArray();

            foreach (var attributeUse in attributes.Items)
            {
                WriteAttributeUse(writer, attributeUse);
            }

            writer.WriteEndArray();
        }

        private static void WriteAttributeUse(IStructuredContentWriter writer, IAstAttributeUse attributeUse)
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

        private static void WriteKeyedLiteralAttributeUse(IStructuredContentWriter writer, KeyedLiteralAstAttributeUse keyedLiteral)
        {
            writer.WriteString("key", keyedLiteral.Key.ToString());

            writer.WriteString("value", keyedLiteral.Literal.ToString());
        }

        private static void WriteKeyedTypedAttributeUse(IStructuredContentWriter writer, KeyedTypedAstAttributeUse keyedTyped)
        {
            writer.WriteString("key", keyedTyped.Key.ToString());

            writer.WriteString("attrType", keyedTyped.Type.ToString());

            writer.WritePropertyName("value");

            ValueInitializationWriter.WriteStructValueInitialization(writer, keyedTyped.Initialization);
        }

        private static void WriteKeyedStructInitializationAttributeUse(IStructuredContentWriter writer, KeyedStructInitializationAstAttributeUse typed)
        {
            writer.WriteString("key", typed.Key.ToString());
            
            writer.WritePropertyName("value");

            ValueInitializationWriter.WriteStructValueInitialization(writer, typed.Initialization);
        }

        private static void WriteTypedAttributeUse(IStructuredContentWriter writer, AstTypedStructInitializationUse typed)
        {
            writer.WriteString("attrType", typed.Type.ToString());

            writer.WritePropertyName("value");

            ValueInitializationWriter.WriteStructValueInitialization(writer, typed.Initialization);
        }

        private static void WriteConditionalAttributeUse(IStructuredContentWriter writer, ConditionalAstAttributeUse conditional)
        {
            writer.WriteString("attrType", conditional.Type.ToString());

            writer.WritePropertyName("expression");

            ConditionalExpressionWriter.WriteConditionalExpression(writer, conditional.ConditionalExpression);
        }
    }
}
