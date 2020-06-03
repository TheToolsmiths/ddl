using System.Linq.Expressions;
using TheToolsmiths.Ddl.Parser.Models.Types.References;

namespace TheToolsmiths.Ddl.Parser.Models.AttributeUsage
{
    public class ConditionalAttributeUse : BaseAttributeUse
    {
        public ConditionalAttributeUse(TypeReference type, ConditionalExpression conditionalExpression)
        {
            this.Type = type;
            this.ConditionalExpression = conditionalExpression;
        }

        public TypeReference Type { get; }

        public ConditionalExpression ConditionalExpression { get; }

        public override AttributeUseKind UseKind => AttributeUseKind.Conditional;
        
        public override bool IsKeyed => false;

        public override bool IsTyped => true;
    }
}
