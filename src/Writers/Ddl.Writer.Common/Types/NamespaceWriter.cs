using TheToolsmiths.Ddl.Models.Types;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer.Common.Types
{
    public class NamespaceWriter
    {
        public Result Write(IRootEntryWriterContext context, NamespacePath namespacePath)
        {
            context.Writer.WriteStartObject();

            context.Writer.WriteBoolean("rooted", namespacePath.IsRooted);

            //context.Writer.WriteStartArray("identifiers");

            //foreach (string identifier in namespacePath.Identifiers)
            //{
            //    context.Writer.WriteStringValue(identifier);
            //}

            //context.Writer.WriteEndArray();

            string path = string.Join(TypeConstants.TypeSeparator, namespacePath.Identifiers);

            context.Writer.WriteString("path", path);

            context.Writer.WriteEndObject();

            return Result.Success;
        }
    }
}
