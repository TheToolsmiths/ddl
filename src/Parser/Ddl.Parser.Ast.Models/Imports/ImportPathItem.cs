using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Models.Imports
{
    public class ImportPathItem : ImportItem
    {
        public ImportPathItem(ImportItem childItem, Identifier pathIdentifier)
        {
            this.ChildItem = childItem;
            this.PathIdentifier = pathIdentifier;
        }

        public ImportItem ChildItem { get; }

        public Identifier PathIdentifier { get; }

        public override ImportedItemKind ItemKind => ImportedItemKind.PathItem;
    }
}
