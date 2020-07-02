using TheToolsmiths.Ddl.Parser.Ast.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes
{
    public abstract class AstRootScopeBase : IAstRootScope
    {
        protected AstRootScopeBase(AstScopeContent content)
        {
            this.Content = content;
        }

        public abstract AstScopeType ScopeType { get; }
        
        public AstScopeContent Content { get; }
    }


}
