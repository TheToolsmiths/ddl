using TheToolsmiths.Ddl.Models.Ast.AttributeUsage;
using TheToolsmiths.Ddl.Models.Ast.EntryTypes;

namespace TheToolsmiths.Ddl.Models.Ast.ContentUnits.Scopes
{
    public class AstRootScope : AstRootScopeBase
    {
        public AstRootScope(AstScopeContent content, AstAttributeUseCollection attributes)
            : base(content, attributes)
        {
        }

        public override AstScopeType ScopeType => CommonScopeTypes.RootScope;
    }
}
