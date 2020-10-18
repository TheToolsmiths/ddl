using TheToolsmiths.Ddl.Models.Compiled.Types.Usage;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Models.Compiled.AttributeUsage
{
    public class ConditionalCompiledAttributeUse : BaseCompiledAttributeUse
    {
        public ConditionalCompiledAttributeUse(ResolvedTypeUse type, ConditionalExpression conditionalExpression)
        {
            this.Type = type;
            this.ConditionalExpression = conditionalExpression;
        }

        public ResolvedTypeUse Type { get; }

        public ConditionalExpression ConditionalExpression { get; }

        public override CompiledAttributeUseKind UseKind => CompiledAttributeUseKind.Conditional;

        public override bool IsKeyed => false;

        public override bool IsTyped => true;
    }
}
