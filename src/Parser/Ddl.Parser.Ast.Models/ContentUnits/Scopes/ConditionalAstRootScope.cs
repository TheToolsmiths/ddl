using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Ast.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Parser.Ast.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes
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
