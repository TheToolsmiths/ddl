namespace TheToolsmiths.Ddl.Parser.Ast.Models.ImportStatements
{
    public abstract class ImportItem
    {
        public abstract ImportedItemKind ItemKind { get; }
    }
}
