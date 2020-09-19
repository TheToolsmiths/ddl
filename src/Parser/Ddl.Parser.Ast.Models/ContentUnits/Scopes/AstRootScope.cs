using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Ast.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes
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
