using System;
using TheToolsmiths.Ddl.Models.Build.Types.Paths;
using TheToolsmiths.Ddl.Models.Build.Types.Usage;
using TheToolsmiths.Ddl.Models.Types.Names;
using TheToolsmiths.Ddl.Models.Types.Usage.Locality;
using TheToolsmiths.Ddl.Models.Types.Usage.Modifiers;
using TheToolsmiths.Ddl.Models.Types.Usage.Storage;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer.Common.Types
{
    public class TypeReferenceWriter
    {
        public Result Write(IRootEntryWriterContext context, TypeUse typeUse)
        {
            context.Writer.WriteStartObject();

            this.WriteTypePath(context, typeUse.TypePath);

            this.WriteLocality(context, typeUse.Locality);

            this.WriteModifiers(context, typeUse.Modifiers);

            this.WriteStorage(context, typeUse.Storage);
            
            throw new System.NotImplementedException();

            //this.WriteResolve(context, typeReference.TypeResolve);

            //context.Writer.WriteEndObject();

            //return Result.Success;
        }

        private void WriteTypePath(IRootEntryWriterContext context, TypePath typePath)
        {
            throw new NotImplementedException();
        }

        private void WriteStorage(IRootEntryWriterContext context, TypeUseStorage storage)
        {
            throw new NotImplementedException();
        }

        private void WriteLocality(IRootEntryWriterContext context, TypeUseLocality locality)
        {
            throw new NotImplementedException();
        }

        private void WriteModifiers(IRootEntryWriterContext context, TypeUseModifiers modifiers)
        {
            throw new NotImplementedException();
        }

        //private void WriteResolve(IRootEntryWriterContext context, ResolveStateHandle resolveState)
        //{
        //    throw new NotImplementedException();
        //}

        private void WriteIdentifier(IRootEntryWriterContext context, TypeNameIdentifier identifier)
        {
            switch (identifier)
            {
                case GenericTypeNameIdentifier genericIdentifier:
                    this.WriteGenericIdentifier(context, genericIdentifier);
                    break;
                case SimpleTypeNameIdentifier simpleIdentifier:
                    this.WriteSimpleIdentifier(context, simpleIdentifier);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(identifier));
            }
        }

        private void WriteSimpleIdentifier(IRootEntryWriterContext context, SimpleTypeNameIdentifier identifier)
        {
            context.Writer.WriteString("name", identifier.Name);
            context.Writer.WriteString("kind", "simple");
        }

        private void WriteGenericIdentifier(IRootEntryWriterContext context, GenericTypeNameIdentifier identifier)
        {
            context.Writer.WriteString("name", identifier.Name);
            context.Writer.WriteString("kind", "generic");

            context.Writer.WriteStartArray("parameters");

            foreach (var genericParameter in identifier.GenericParameters)
            {
                context.Writer.WriteStartObject();

                context.Writer.WriteString("name", genericParameter.Text);

                context.Writer.WriteEndObject();
            }

            context.Writer.WriteEndArray();
        }
    }
}
