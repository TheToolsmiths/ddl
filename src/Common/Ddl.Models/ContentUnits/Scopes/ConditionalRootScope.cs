using TheToolsmiths.Ddl.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Models.ContentUnits.Scopes
{
    public class ConditionalRootScope : RootScope
    {
        public ConditionalRootScope(
            ConditionalExpression conditionalExpression,
            ScopeContent content)
            : base(content)
        {
            this.ConditionalExpression = conditionalExpression;
        }

        public ConditionalExpression ConditionalExpression { get; }
    }
}
