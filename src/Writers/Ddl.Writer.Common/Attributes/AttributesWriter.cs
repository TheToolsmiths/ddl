using System;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer.Common.Attributes
{
    public class AttributesWriter
    {
        public Result Write(IRootEntryWriterContext context, AttributeUseCollection attributeUseCollection)
        {
            context.Writer.WriteStartArray();

            foreach (var attributeUse in attributeUseCollection.Items)
            {
                this.WriteAttributeUse(context, attributeUse);
            }

            context.Writer.WriteEndArray();

            return Result.Success;
        }

        private void WriteAttributeUse(IRootEntryWriterContext context, IAttributeUse attributeUse)
        {
            switch (attributeUse)
            {
                case ConditionalAttributeUse conditional:
                    this.WriteConditionalAttribute(context, conditional);
                    break;
                case KeyedLiteralAttributeUse keyedLiteral:
                    this.WriteLiteralAttribute(context, keyedLiteral);
                    break;
                case KeyedStructInitializationAttributeUse keyedStructInitialization:
                    this.WriteKeyedStructInitializationAttribute(context, keyedStructInitialization);
                    break;
                case KeyedTypedAttributeUse keyedTyped:
                    this.WriteKeyedTypedAttribute(context, keyedTyped);
                    break;
                case TypedStructInitializationUse typedStructInitialization:
                    this.WriteTypedStructInitializationAttribute(context, typedStructInitialization);
                    break;
                case TypedInitializationUse typedInitialization:
                    this.WriteTypedInitializationAttribute(context, typedInitialization);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(attributeUse));
            }

            throw new NotImplementedException();
        }

        private void WriteTypedInitializationAttribute(
            IRootEntryWriterContext context,
            TypedInitializationUse typedInitialization)
        {
            throw new NotImplementedException();
        }

        private void WriteTypedStructInitializationAttribute(
            IRootEntryWriterContext context,
            TypedStructInitializationUse typedStructInitialization)
        {
            throw new NotImplementedException();
        }

        private void WriteKeyedTypedAttribute(IRootEntryWriterContext context, KeyedTypedAttributeUse keyedTyped)
        {
            throw new NotImplementedException();
        }

        private void WriteKeyedStructInitializationAttribute(
            IRootEntryWriterContext context,
            KeyedStructInitializationAttributeUse keyedStructInitialization)
        {
            throw new NotImplementedException();
        }

        private void WriteLiteralAttribute(IRootEntryWriterContext context, KeyedLiteralAttributeUse keyedLiteral)
        {
            throw new NotImplementedException();
        }

        private void WriteConditionalAttribute(IRootEntryWriterContext context, ConditionalAttributeUse conditional)
        {
            throw new NotImplementedException();
        }
    }
}
