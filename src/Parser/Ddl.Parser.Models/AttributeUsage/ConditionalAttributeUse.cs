using TheToolsmiths.Ddl.Parser.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Parser.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Models.AttributeUsage
{
    public class ConditionalAttributeUse : BaseAttributeUse
    {
        public ConditionalAttributeUse(ITypeIdentifier type, ConditionalExpression conditionalExpression)
        {
            this.Type = type;
            this.ConditionalExpression = conditionalExpression;
        }

        public ITypeIdentifier Type { get; }

        public ConditionalExpression ConditionalExpression { get; }

        public override AttributeUseType UseType => AttributeUseType.Conditional;
        
        public override bool IsKeyed => false;

        public override bool IsTyped => true;
    }
}
