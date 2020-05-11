using TheToolsmiths.Ddl.Parser.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Parser.Models.ContentUnits.Scopes
{
    public class ConditionalRootScope : RootScope
    {
        public ConditionalRootScope(
            ConditionalExpression conditionalExpression,
            RootScopeContent content)
            : base(content)
        {
            this.ConditionalExpression = conditionalExpression;
        }

        public override ContentUnitScopeType ScopeType => ContentUnitScopeType.RootScope;

        public ConditionalExpression ConditionalExpression { get; }
    }
}
