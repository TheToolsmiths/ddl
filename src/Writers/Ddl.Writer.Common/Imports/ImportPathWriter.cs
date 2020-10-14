﻿using TheToolsmiths.Ddl.Models.Build.ImportPaths;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer.Common.Imports
{
    public static class ImportPathWriter
    {
        public static void WriteImportPath(IStructuredContentWriter writer, ImportStatement importStatement)
        {
            writer.WriteStartObject();

            writer.WriteString("alias", importStatement.Alias);
            writer.WriteString("path", importStatement.ImportPath.ToString());

            writer.WriteEndObject();
        }
    }
}
