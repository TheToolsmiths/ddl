using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.FileContents;

namespace TheToolsmiths.Ddl.Models.Imports
{
    public class ImportStatement : IRootContentItem
    {
        public ImportStatement(IReadOnlyList<ImportedItem> items, string path)
        {
            this.Items = items;
            this.Path = path;
        }

        public IReadOnlyList<ImportedItem> Items { get; }

        public string Path { get; }

        public FileContentItemType ItemType => FileContentItemType.ImportStatement;
    }
}
