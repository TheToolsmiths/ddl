using TheToolsmiths.Ddl.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.TypeResolution.Scopes.Properties
{
    public class ConditionalProperty : ScopeProperty
    {
        public ConditionalProperty(ConditionalExpression rootScopeConditionalExpression)
            : base(
                ScopePropertyKind.Conditional,
                nameof(ScopePropertyKind.Conditional))
        {
            this.RootScopeConditionalExpression = rootScopeConditionalExpression;
        }

        public ConditionalExpression RootScopeConditionalExpression { get; }
    }
}
