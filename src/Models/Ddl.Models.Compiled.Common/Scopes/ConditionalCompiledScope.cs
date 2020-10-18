using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Models.Compiled.Scopes
{
    public class ConditionalCompiledScope : CompiledScopeBase, IAttributableCompiledScope
    {
        public ConditionalCompiledScope(
            ConditionalExpression conditionalExpression,
            CompiledScopeContent content,
            CompiledAttributeUseCollection attributes)
            : base(content)
        {
            this.ConditionalExpression = conditionalExpression;
            this.Attributes = attributes;
        }

        public CompiledAttributeUseCollection Attributes { get; }

        public ConditionalExpression ConditionalExpression { get; }

        public override ScopeType ScopeType => CommonScopeTypes.ConditionalScope;
    }
}
