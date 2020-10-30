using System;

using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer.Common.Attributes
{
    public class CompiledAttributesWriter
    {
        public Result Write(ICompiledEntryWriterContext context, CompiledAttributeUseCollection attributeUseCollection)
        {
            context.Writer.WriteStartArray();

            foreach (var attributeUse in attributeUseCollection.Items)
            {
                this.WriteAttributeUse(context, attributeUse);
            }

            context.Writer.WriteEndArray();

            return Result.Success;
        }

        private void WriteAttributeUse(ICompiledEntryWriterContext context, ICompiledAttributeUse attributeUse)
        {
            context.Writer.WriteStartObject();

            switch (attributeUse)
            {
                case ConditionalCompiledAttributeUse conditional:
                    this.WriteConditionalAttribute(context, conditional);
                    break;
                case CompiledKeyedLiteralAttributeUse keyedLiteral:
                    this.WriteLiteralAttribute(context, keyedLiteral);
                    break;
                case CompiledKeyedStructInitializationAttributeUse keyedStructInitialization:
                    this.WriteKeyedStructInitializationAttribute(context, keyedStructInitialization);
                    break;
                case CompiledKeyedTypedAttributeUse keyedTyped:
                    this.WriteKeyedTypedAttribute(context, keyedTyped);
                    break;
                case CompiledTypedInitializationUse typedInitialization:
                    this.WriteTypedInitializationAttribute(context, typedInitialization);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(attributeUse));
            }

            context.Writer.WriteEndObject();
        }

        private void WriteTypedInitializationAttribute(
            ICompiledEntryWriterContext context,
            CompiledTypedInitializationUse typedInitialization)
        {
            context.Writer.WriteString("kind", "typed-struct");

            context.Writer.WritePropertyName("type");
            context.CommonWriters.WriteTypeUse(typedInitialization.Type);

            context.Writer.WritePropertyName("initialization");
            context.CommonWriters.WriteStructInitialization(typedInitialization.Initialization);
        }

        private void WriteKeyedTypedAttribute(ICompiledEntryWriterContext context, CompiledKeyedTypedAttributeUse keyedTyped)
        {
            context.Writer.WriteString("kind", "keyed-typed");

            context.Writer.WriteString("key", keyedTyped.Key);

            context.Writer.WritePropertyName("type");
            context.CommonWriters.WriteTypeUse(keyedTyped.Type);

            context.Writer.WritePropertyName("initialization");
            context.CommonWriters.WriteStructInitialization(keyedTyped.Initialization);
        }

        private void WriteKeyedStructInitializationAttribute(
            ICompiledEntryWriterContext context,
            CompiledKeyedStructInitializationAttributeUse keyedStructInitialization)
        {
            context.Writer.WriteString("kind", "keyed-typed");

            context.Writer.WriteString("key", keyedStructInitialization.Key);

            context.Writer.WritePropertyName("initialization");
            context.CommonWriters.WriteStructInitialization(keyedStructInitialization.Initialization);
        }

        private void WriteLiteralAttribute(ICompiledEntryWriterContext context, CompiledKeyedLiteralAttributeUse keyedLiteral)
        {
            context.Writer.WriteString("kind", "keyed-literal");

            context.Writer.WriteString("key", keyedLiteral.Key);

            context.CommonWriters.WriteLiteralValue(keyedLiteral.Literal);
        }

        private void WriteConditionalAttribute(ICompiledEntryWriterContext context, ConditionalCompiledAttributeUse conditional)
        {
            context.Writer.WriteString("kind", "conditional");

            context.Writer.WritePropertyName("condition");
            context.CommonWriters.WriteConditionalExpression(conditional.ConditionalExpression);
        }
    }
}
