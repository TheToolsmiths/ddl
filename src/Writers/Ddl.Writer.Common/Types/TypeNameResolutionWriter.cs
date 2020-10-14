using System;
using TheToolsmiths.Ddl.Models.Paths;
using TheToolsmiths.Ddl.Models.Types.Names;
using TheToolsmiths.Ddl.Models.Types.Names.Qualified;
using TheToolsmiths.Ddl.Models.Types.Names.Qualified.Resolution;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer.Common.Types
{
    public class TypeNameResolutionWriter
    {
        public Result Write(IRootItemWriterContext context, QualifiedItemTypeNameResolution typeNameResolution)
        {
            context.Writer.WriteStartObject();

            switch (typeNameResolution)
            {
                case ResolvedQualifiedItemTypeName resolvedTypeName:
                    this.WriteResolvedTypeName(context, resolvedTypeName.TypeName);
                    break;
                case UnresolvedQualifiedItemTypeName _:
                    this.WriteUnresolvedTypeName(context);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(typeNameResolution));
            }

            context.Writer.WriteEndObject();

            return Result.Success;
        }

        private void WriteUnresolvedTypeName(IRootItemWriterContext context)
        {
            context.Writer.WriteString("kind", "unresolved");
        }

        private void WriteResolvedTypeName(
            IRootItemWriterContext context,
            QualifiedItemTypeName typeName)
        {
            context.Writer.WriteString("kind", "resolved");

            var itemName = typeName.ItemName.ItemName;

            context.Writer.WriteString("typeName", itemName.Name);

            string typeNameKind = itemName.IdentifierKind switch
            {
                PathPartKind.Simple => "simple",
                PathPartKind.Generic => "generic"
            };

            context.Writer.WriteString("typeNameKind", typeNameKind);

            if (itemName is GenericTypeNameIdentifier genericIdentifier)
            {
                context.Writer.WriteStartArray("parameters");

                foreach (var genericParameter in genericIdentifier.GenericParameters)
                {
                    context.Writer.WriteStartObject();

                    context.Writer.WriteString("name", genericParameter.Text);

                    context.Writer.WriteEndObject();
                }

                context.Writer.WriteEndArray();
            }

            context.Writer.WriteString("namespace", typeName.NamespacePath.ToString());
        }
    }
}
