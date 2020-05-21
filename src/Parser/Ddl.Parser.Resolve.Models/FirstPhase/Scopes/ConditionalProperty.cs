using TheToolsmiths.Ddl.Parser.Ast.Models.ConditionalExpressions;

namespace Ddl.Parser.Resolve.Models.FirstPhase.Scopes
{
    public class ConditionalProperty : FirstPhaseResolvedScopeProperty
    {
        public ConditionalProperty(ConditionalExpression rootScopeConditionalExpression)
            : base(
                FirstPhaseResolvedScopePropertyKind.Conditional,
                nameof(FirstPhaseResolvedScopePropertyKind.Conditional))
        {
            this.RootScopeConditionalExpression = rootScopeConditionalExpression;
        }

        public ConditionalExpression RootScopeConditionalExpression { get; }
    }
}