namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes
{
    public abstract class AstRootScope : IAstRootScope
    {
        protected AstRootScope(AstScopeContent content)
        {
            this.Content = content;
        }

        public abstract AstContentUnitScopeType ScopeType { get; }
        
        public AstScopeContent Content { get; }
    }


}
