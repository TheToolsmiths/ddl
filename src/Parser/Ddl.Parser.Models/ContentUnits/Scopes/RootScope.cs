namespace TheToolsmiths.Ddl.Parser.Models.ContentUnits.Scopes
{
    public abstract class RootScope : IRootScope
    {
        protected RootScope(RootScopeContent content)
        {
            this.Content = content;
        }

        public abstract ContentUnitScopeType ScopeType { get; }
        
        public RootScopeContent Content { get; }
    }


}
