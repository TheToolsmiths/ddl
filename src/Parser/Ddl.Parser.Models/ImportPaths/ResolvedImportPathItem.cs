namespace TheToolsmiths.Ddl.Parser.Models.ImportPaths
{
    public class ResolvedImportPathItem : ResolvedImportItem
    {
        public ResolvedImportPathItem(ResolvedImportItem childItem, string pathIdentifier)
        {
            this.ChildItem = childItem;
            this.PathIdentifier = pathIdentifier;
        }

        public ResolvedImportItem ChildItem { get; }

        public string PathIdentifier { get; }

        public override ResolvedImportedItemKind ItemKind => ResolvedImportedItemKind.PathItem;

        public override string ToString()
        {
            return $"{this.PathIdentifier}::{this.ChildItem}";
        }
    }
}
