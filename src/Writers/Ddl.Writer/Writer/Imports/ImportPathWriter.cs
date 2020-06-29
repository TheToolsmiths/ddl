using TheToolsmiths.Ddl.Models.ImportPaths;
using TheToolsmiths.Ddl.Writer.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer.Writer.Imports
{
    public static class ImportPathWriter
    {
        public static void WriteImportPath(IStructuredWriter writer, ImportStatement importStatement)
        {
            writer.WriteStartObject();

            writer.WriteString("alias", importStatement.Alias);
            writer.WriteString("path", importStatement.ImportPath.ToString());

            writer.WriteEndObject();
        }
    }
}
