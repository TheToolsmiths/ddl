using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.FileContents;

namespace TheToolsmiths.Ddl.Parser.Models.Imports
{
    public class ImportStatement : RootContentItem
    {
        public ImportStatement(IReadOnlyList<ImportedItem> items, string path)
        {
            this.Items = items;
            this.Path = path;
        }

        public IReadOnlyList<ImportedItem> Items { get; }

        public string Path { get; }

        public override FileContentItemType ItemType => FileContentItemType.ImportStatement;
    }
}
