using TheToolsmiths.Ddl.Models.Compiled.Types.Names;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer.Common.Types
{
    public class QualifiedTypeNameWriter
    {
        public Result Write(ICompiledEntryWriterContext context, QualifiedItemTypeName typeName)
        {
            context.Writer.WriteStartObject();

            context.Writer.WritePropertyName("namespace");
            context.CommonWriters.WriteQualifiedNamespace(typeName.NamespacePath);

            context.Writer.WritePropertyName("name");
            context.CommonWriters.WriteTypeNameIdentifier(typeName.ItemTypeName.ItemName);

            context.Writer.WriteEndObject();

            return Result.Success;
        }
    }
}
