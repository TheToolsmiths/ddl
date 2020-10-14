using TheToolsmiths.Ddl.Models.Ast.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.Ast.Types.Identifiers;

namespace TheToolsmiths.Ddl.Models.Ast.AttributeUsage
{
    public class ConditionalAstAttributeUse : BaseAstAttributeUse
    {
        public ConditionalAstAttributeUse(ITypeIdentifier type, AstConditionalExpression conditionalExpression)
        {
            this.Type = type;
            this.ConditionalExpression = conditionalExpression;
        }

        public ITypeIdentifier Type { get; }

        public AstConditionalExpression ConditionalExpression { get; }

        public override AttributeUseKind UseKind => AttributeUseKind.Conditional;
        
        public override bool IsKeyed => false;

        public override bool IsTyped => true;
    }
}
