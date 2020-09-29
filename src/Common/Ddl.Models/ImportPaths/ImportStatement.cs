using System;

using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Models.ImportPaths
{
    public class ImportStatement : IRootItem
    {
        private ImportStatement(ImportPath importPath, string aliasIdentifier)
        {
            this.ImportPath = importPath;
            this.Alias = aliasIdentifier;
            this.ItemId = ItemId.CreateNew();
        }

        public ItemType ItemType => CommonItemTypes.ImportStatement;

        public ItemId ItemId { get; }

        public ImportPath ImportPath { get; }

        public string Alias { get; }

        public override string ToString()
        {
            return $"{this.ImportPath} as {this.Alias}";
        }

        public static ImportStatement Create(ImportPath importPath)
        {
            string? alias = importPath.PathParts[^1].Name;

            if (alias == null)
            {
                throw new ArgumentException(nameof(importPath));
            }

            return new ImportStatement(importPath, alias);
        }

        public static ImportStatement CreateWithAlias(ImportPath importPath, string alias)
        {
            return new ImportStatement(importPath, alias);
        }
    }
}
