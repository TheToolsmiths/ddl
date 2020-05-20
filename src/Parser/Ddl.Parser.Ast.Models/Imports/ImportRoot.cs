namespace TheToolsmiths.Ddl.Parser.Models.Imports
{
    public class ImportRoot : ImportItem
    {
        public ImportRoot(ImportItem childItem)
        {
            this.ChildItem = childItem;
        }

        public ImportItem ChildItem { get; }

        public override ImportedItemKind ItemKind => ImportedItemKind.Root;

        public static ImportRoot CreateWithChildItem(ImportItem childItem)
        {
            return new ImportRoot(childItem);
        }
    }
}
