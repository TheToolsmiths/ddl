using TheToolsmiths.Ddl.Models.Ast.Identifiers;

namespace TheToolsmiths.Ddl.Models.Ast.ImportStatements
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
