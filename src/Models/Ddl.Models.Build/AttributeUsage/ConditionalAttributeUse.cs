using TheToolsmiths.Ddl.Models.Build.Types.Usage;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Models.Build.AttributeUsage
{
    public class ConditionalAttributeUse : BaseAttributeUse
    {
        public ConditionalAttributeUse(TypeUse type, ConditionalExpression conditionalExpression)
        {
            this.Type = type;
            this.ConditionalExpression = conditionalExpression;
        }

        public TypeUse Type { get; }

        public ConditionalExpression ConditionalExpression { get; }

        public override AttributeUseKind UseKind => AttributeUseKind.Conditional;

        public override bool IsKeyed => false;

        public override bool IsTyped => true;
    }
}
