using TheToolsmiths.Ddl.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.Types;

namespace TheToolsmiths.Ddl.Models.AttributeUsage
{
    public class ConditionalAttributeUse : BaseAttributeUse
    {
        public ConditionalAttributeUse(TypeIdentifier type, ConditionalExpression conditionalExpression)
        {
            this.Type = type;
            this.ConditionalExpression = conditionalExpression;
        }

        public TypeIdentifier Type { get; }

        public ConditionalExpression ConditionalExpression { get; }

        public override AttributeUseType UseType => AttributeUseType.Typed;
        
        public override bool IsKeyed => false;

        public override bool IsTyped => true;
    }
}
