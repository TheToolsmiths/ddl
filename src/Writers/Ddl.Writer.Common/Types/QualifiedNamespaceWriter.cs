using TheToolsmiths.Ddl.Models.Compiled.Namespaces.Paths;
using TheToolsmiths.Ddl.Models.Types;
using TheToolsmiths.Ddl.Results;
using TheToolsmiths.Ddl.Writer.Contexts;

namespace TheToolsmiths.Ddl.Writer.Common.Types
{
    public class QualifiedNamespaceWriter
    {
        public Result Write(ICompiledEntryWriterContext context, QualifiedNamespacePath namespacePath)
        {
            context.Writer.WriteStartObject();

            string path = string.Join(TypeConstants.TypeSeparator, namespacePath.Identifiers);

            context.Writer.WriteString("path", path);

            context.Writer.WriteEndObject();

            return Result.Success;
        }
    }
}
