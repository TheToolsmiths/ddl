using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ImportStatements
{
    public class ImportGroup : ImportItem
    {
        public ImportGroup(IReadOnlyList<ImportItem> childItems)
        {
            this.ChildItems = childItems;
        }

        public IReadOnlyList<ImportItem> ChildItems { get; }

        public override ImportedItemKind ItemKind => ImportedItemKind.Group;

        public static ImportGroup Create(IReadOnlyList<ImportItem> childItems)
        {
            return new ImportGroup(childItems);
        }
    }
}
