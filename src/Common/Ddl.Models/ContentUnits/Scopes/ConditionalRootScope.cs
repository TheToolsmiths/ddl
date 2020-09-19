using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Models.ContentUnits.Scopes
{
    public class ConditionalRootScope : RootScopeBase
    {
        public ConditionalRootScope(
            ConditionalExpression conditionalExpression,
            ScopeContent content,
            AttributeUseCollection attributes)
            : base(content, attributes)
        {
            this.ConditionalExpression = conditionalExpression;
        }

        public ConditionalExpression ConditionalExpression { get; }

        public override ScopeType ScopeType => CommonScopeTypes.ConditionalScope;
    }
}
