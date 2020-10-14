using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;
using TheToolsmiths.Ddl.Models.Compiled.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.Compiled.EntryTypes;

namespace TheToolsmiths.Ddl.Models.Compiled.ContentUnits.Scopes
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
