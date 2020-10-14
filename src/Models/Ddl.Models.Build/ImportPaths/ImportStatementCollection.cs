using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.Build.ImportPaths
{
    public class ImportStatementCollection
    {
        private ImportStatementCollection(IReadOnlyList<ImportStatement> items)
        {
            this.Items = items;
        }

        public static ImportStatementCollection Empty { get; } = Create(new List<ImportStatement>());

        public bool HasAttributes => this.Items.Count > 0;

        public IReadOnlyList<ImportStatement> Items { get; }

        public static ImportStatementCollection Create(IReadOnlyList<ImportStatement> importPaths)
        {
            return new ImportStatementCollection(importPaths);
        }
    }
}
