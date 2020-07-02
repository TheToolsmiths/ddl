using TheToolsmiths.Ddl.Parser.Ast.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Parser.Ast.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes
{
    public class ConditionalAstRootScope : AstRootScopeBase
    {
        public ConditionalAstRootScope(
            ConditionalExpression conditionalExpression,
            AstScopeContent content)
            : base(content)
        {
            this.ConditionalExpression = conditionalExpression;
        }

        public override AstScopeType ScopeType => CommonScopeTypes.ConditionalScope;

        public ConditionalExpression ConditionalExpression { get; }
    }
}
