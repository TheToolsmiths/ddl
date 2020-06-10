using System;
using System.Text.Json;
using TheToolsmiths.Ddl.Parser.Ast.Models.Imports;

namespace TheToolsmiths.Ddl.Transpiler.Transpilers
{
    public static class ImportStatementTranspiler
    {
        public static void WriteImportStatement(Utf8JsonWriter writer, ImportAstStatement importStatement)
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
