namespace TheToolsmiths.Ddl.Parser.Models.ContentUnits.Scopes
{
    public class FileRootScope : IFileRootScope
    {
        public FileRootScope(ScopeContent content)
        {
            this.Content = content;
        }

        public ScopeContent Content { get; }
    }
}
