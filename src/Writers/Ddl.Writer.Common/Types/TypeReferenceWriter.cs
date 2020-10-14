using System;
using TheToolsmiths.Ddl.Models.Build.Types.Names;
using TheToolsmiths.Ddl.Models.Build.Types.References;
using TheToolsmiths.Ddl.Models.Build.Types.References.Locality;
using TheToolsmiths.Ddl.Models.Build.Types.References.Modifiers;
using TheToolsmiths.Ddl.Models.Build.Types.References.Resolve;
using TheToolsmiths.Ddl.Models.Build.Types.References.Storage;
using TheToolsmiths.Ddl.Models.Build.Types.TypePaths.References;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer.Common.Types
{
    public class TypeReferenceWriter
    {
        public Result Write(IRootEntryWriterContext context, TypeReference typeReference)
        {
            context.Writer.WriteStartObject();

            this.WriteTypePath(context, typeReference.TypePath);

            this.WriteLocality(context, typeReference.Locality);

            this.WriteModifiers(context, typeReference.Modifiers);

            this.WriteStorage(context, typeReference.Storage);

            this.WriteResolve(context, typeReference.TypeResolve);

            context.Writer.WriteEndObject();

            return Result.Success;
        }

        private void WriteTypePath(IRootEntryWriterContext context, TypeReferencePath typePath)
        {
            throw new NotImplementedException();
        }

        private void WriteStorage(IRootEntryWriterContext context, TypeStorage storage)
        {
            throw new NotImplementedException();
        }

        private void WriteLocality(IRootEntryWriterContext context, TypeLocalityInformation locality)
        {
            throw new NotImplementedException();
        }

        private void WriteModifiers(IRootEntryWriterContext context, TypeModifiers modifiers)
        {
            throw new NotImplementedException();
        }

        private void WriteResolve(IRootEntryWriterContext context, ResolveStateHandle resolveState)
        {
            throw new NotImplementedException();
        }

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
