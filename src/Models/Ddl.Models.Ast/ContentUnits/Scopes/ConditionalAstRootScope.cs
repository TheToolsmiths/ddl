using TheToolsmiths.Ddl.Models.Ast.AttributeUsage;
using TheToolsmiths.Ddl.Models.Ast.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.Ast.EntryTypes;

namespace TheToolsmiths.Ddl.Models.Ast.ContentUnits.Scopes
{
    public class ConditionalAstRootScope : AstRootScopeBase
    {
        public ConditionalAstRootScope(
            AstConditionalExpression conditionalExpression,
            AstScopeContent content,
            AstAttributeUseCollection attributes)
            : base(content, attributes)
        {
            this.ConditionalExpression = conditionalExpression;
        }

        public override AstScopeType ScopeType => CommonScopeTypes.ConditionalScope;

        public AstConditionalExpression ConditionalExpression { get; }
    }
}
