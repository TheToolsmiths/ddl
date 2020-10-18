using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.ImportPaths;
using TheToolsmiths.Ddl.Models.Build.Items;
using TheToolsmiths.Ddl.Models.Build.Scopes;
using TheToolsmiths.Ddl.Writer.Common.Imports;
using TheToolsmiths.Ddl.Writer.Output.StructuredWriters;

namespace TheToolsmiths.Ddl.Writer.Common.Scopes
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

            throw new NotImplementedException();

            //foreach (var rootItem in items)
            //{
            //    RootItemWriter.WriteItem(writer, rootItem);
            //}

            writer.WriteEndArray();
        }

        private static void WriteScopes(IStructuredContentWriter writer, IEnumerable<IRootScope> scopes)
        {
            writer.WriteStartArray("scopes");

            throw new NotImplementedException();

            //foreach (var rootScope in scopes)
            //{
            //    RootScopeWriter.WriteRootScope(writer, rootScope);
            //}

            writer.WriteEndArray();
        }
    }
}
