namespace TheToolsmiths.Ddl.Models.ContentUnits.Scopes
{
    public class RootScope : IRootScope
    {
        public RootScope(ScopeContent content)
        {
            this.Content = content;
        }

        public ScopeContent Content { get; }
    }


}
