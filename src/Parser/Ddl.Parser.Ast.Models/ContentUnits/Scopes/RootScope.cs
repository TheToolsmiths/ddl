namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes
{
    public abstract class RootScope : IRootScope
    {
        protected RootScope(ScopeContent content)
        {
            this.Content = content;
        }

        public abstract ContentUnitScopeType ScopeType { get; }
        
        public ScopeContent Content { get; }
    }


}
