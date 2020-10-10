using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Models.ImportPaths;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;
using TheToolsmiths.Ddl.Writer.Writer.Imports;
using TheToolsmiths.Ddl.Writer.Writer.Items;

namespace TheToolsmiths.Ddl.Writer.Writer.Scopes
{
    public static class ScopeContentWriter
    {
        public static void WriteScopeContent(IStructuredContentWriter writer, ScopeContent content)
        {
            writer.WriteStartObject();

            WriteImportPaths(writer, content.Imports);

            WriteItems(writer, content.Items);

            WriteScopes(writer, content.Scopes);

            writer.WriteEndObject();
        }

        private static void WriteImportPaths(IStructuredContentWriter writer, ImportStatementCollection imports)
        {
            writer.WriteStartArray("imports");

            foreach (var importStatement in imports.Items)
            {
                ImportPathWriter.WriteImportPath(writer, importStatement);
            }

            writer.WriteEndArray();
        }

        private static void WriteItems(IStructuredContentWriter writer, IReadOnlyList<IRootItem> items)
        {
            writer.WriteStartArray("items");

            foreach (var rootItem in items)
            {
                RootItemWriter.WriteItem(writer, rootItem);
            }

            writer.WriteEndArray();
        }

        private static void WriteScopes(IStructuredContentWriter writer, IEnumerable<IRootScope> scopes)
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
