using System;
using TheToolsmiths.Ddl.Parser.Ast.Models.ImportStatements;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer.Parser.Ast.Writers
{
    public static class ImportStatementWriter
    {
        public static void WriteImportStatement(IStructuredContentWriter writer, ImportAstStatement importStatement)
        {
            throw new NotImplementedException();

            //writer.WriteStartObject();

            //writer.WriteString("type", "import");

            //writer.WriteStartArray("items");

            //foreach (var importedItem in importStatement.Items)
            //{
            //    writer.WriteStartObject();

            //    if (importedItem.IsImportAll)
            //    {
            //        writer.WriteBoolean("importAll", true);
            //    }
            //    else
            //    {
            //        writer.WriteString("name", importedItem.Identifier.ToString());
            //    }

            //    if (importedItem.AliasIdentifier.IsValid)
            //    {
            //        writer.WriteString("alias", importedItem.AliasIdentifier.ToString());
            //    }

            //    writer.WriteEndObject();
            //}

            //writer.WriteEndArray();

            //writer.WriteString("path", importStatement.Path);

            //writer.WriteEndObject();
        }
    }
}
