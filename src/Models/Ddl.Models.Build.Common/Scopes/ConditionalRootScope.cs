using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Models.Build.Scopes
{
    public class ConditionalRootScope : RootScopeBase, IAttributableRootScope
    {
        public ConditionalRootScope(
            ConditionalExpression conditionalExpression,
            ScopeContent content,
            AttributeUseCollection attributes)
            : base(content)
        {
            this.ConditionalExpression = conditionalExpression;
            this.Attributes = attributes;
        }

        public AttributeUseCollection Attributes { get; }

        public ConditionalExpression ConditionalExpression { get; }

        public override ScopeType ScopeType => CommonScopeTypes.ConditionalScope;
    }
}
