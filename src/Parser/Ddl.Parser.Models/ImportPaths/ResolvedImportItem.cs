namespace TheToolsmiths.Ddl.Parser.Models.ImportPaths
{
    public abstract class ResolvedImportItem
    {
        public abstract ResolvedImportedItemKind ItemKind { get; }

        public abstract override string ToString();
    }
}
