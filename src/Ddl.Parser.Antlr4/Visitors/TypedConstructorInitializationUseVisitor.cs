using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class TypedConstructorInitializationUseVisitor : BaseVisitor<IAttributeUse>
    {
        public override IAttributeUse VisitTypedCtorInitUse(DdlParser.TypedCtorInitUseContext context)
        {
            ITypeIdentifier type;
            {
                var typeIdentifierContext = context.typeIdentifier();

                var visitor = new TypeIdentifierVisitor();

                type = visitor.VisitTypeIdentifier(typeIdentifierContext);
            }

            ConditionalExpression conditionalExpression;
            {
                var conditionalExpressionContext = context.conditionalExpression();

                var visitor = new ConditionalExpressionVisitor();

                conditionalExpression = visitor.VisitConditionalExpression(conditionalExpressionContext);
            }

            return new ConditionalAttributeUse(type, conditionalExpression);
        }
    }
}