namespace TheToolsmiths.Ddl.Parser.Models.ContentUnits.Scopes
{
    public class FileRootScope : IFileRootScope
    {
        public FileRootScope(RootScopeContent content)
        {
            this.Content = content;
        }

        public RootScopeContent Content { get; }
    }
}
