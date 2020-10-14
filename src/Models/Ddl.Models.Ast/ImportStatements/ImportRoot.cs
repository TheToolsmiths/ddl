namespace TheToolsmiths.Ddl.Models.Ast.ImportStatements
{
    public class ImportRoot
    {
        public ImportRoot(ImportItem childItem, bool isRoot)
        {
            this.ChildItem = childItem;
            this.IsRoot = isRoot;
        }

        public ImportItem ChildItem { get; }

        public bool IsRoot { get; }
    }
}
