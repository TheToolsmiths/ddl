using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Models.ImportPaths;
using TheToolsmiths.Ddl.Writer.StructuredWriters;
using TheToolsmiths.Ddl.Writer.Writer.Imports;
using TheToolsmiths.Ddl.Writer.Writer.Items;

namespace TheToolsmiths.Ddl.Writer.Writer.Scopes
{
    public static class ScopeContentWriter
    {
        public static void WriteScopeContent(IStructuredWriter writer, ScopeContent content)
        {
            writer.WriteStartObject();

            WriteImportPaths(writer, content.ImportPaths);

            WriteItems(writer, content.Items);

            WriteScopes(writer, content.Scopes);

            writer.WriteEndObject();
        }

        private static void WriteImportPaths(IStructuredWriter writer, IReadOnlyList<ImportStatement> imports)
        {
            writer.WriteStartArray("imports");

            foreach (var importStatement in imports)
            {
                ImportPathWriter.WriteImportPath(writer, importStatement);
            }

            writer.WriteEndArray();
        }

        private static void WriteItems(IStructuredWriter writer, IReadOnlyList<IRootItem> items)
        {
            writer.WriteStartArray("items");

            foreach (var rootItem in items)
            {
                RootItemWriter.WriteItem(writer, rootItem);
            }

            writer.WriteEndArray();
        }

        private static void WriteScopes(IStructuredWriter writer, IEnumerable<IRootScope> scopes)
        {
            writer.WriteStartArray("scopes");

            foreach (var rootScope in scopes)
            {
                RootScopeWriter.WriteRootScope(writer, rootScope);
            }

            writer.WriteEndArray();
        }
    }
}
