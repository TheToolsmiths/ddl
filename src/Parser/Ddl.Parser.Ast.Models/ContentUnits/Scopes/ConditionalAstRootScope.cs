using TheToolsmiths.Ddl.Parser.Ast.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes
{
    public class ConditionalAstRootScope : AstRootScope
    {
        public ConditionalAstRootScope(
            ConditionalExpression conditionalExpression,
            AstScopeContent content)
            : base(content)
        {
            this.ConditionalExpression = conditionalExpression;
        }

        public override AstContentUnitScopeType ScopeType => AstContentUnitScopeType.RootScope;

        public ConditionalExpression ConditionalExpression { get; }
    }
}
