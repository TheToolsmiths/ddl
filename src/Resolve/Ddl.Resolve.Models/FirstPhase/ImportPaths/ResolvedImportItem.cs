namespace Ddl.Resolve.Models.FirstPhase.ImportPaths
{
    public abstract class ResolvedImportItem
    {
        public abstract ResolvedImportedItemKind ItemKind { get; }

        public abstract override string ToString();
    }
}
