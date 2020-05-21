using TheToolsmiths.Ddl.Parser.Ast.Models.Identifiers;

namespace Ddl.Parser.Resolve.Models.FirstPhase.ImportPaths
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
