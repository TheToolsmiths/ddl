using TheToolsmiths.Ddl.Parser.Ast.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes
{
    public class AstRootScope : AstRootScopeBase
    {
        public AstRootScope(AstScopeContent content)
            : base(content)
        {
        }

        public override AstScopeType ScopeType => CommonScopeTypes.RootScope;
    }
}
