using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Models.ImportPaths
{
    public class ResolvedImportPathItem : ResolvedImportItem
    {
        public ResolvedImportPathItem(ResolvedImportItem childItem, Identifier pathIdentifier)
        {
            this.ChildItem = childItem;
            this.PathIdentifier = pathIdentifier;
        }

        public ResolvedImportItem ChildItem { get; }

        public Identifier PathIdentifier { get; }

        public override ResolvedImportedItemKind ItemKind => ResolvedImportedItemKind.PathItem;

        public override string ToString()
        {
            return $"{this.PathIdentifier}::{this.ChildItem}";
        }
    }
}
