using TheToolsmiths.Ddl.Parser.Models;
using TheToolsmiths.Ddl.Parser.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class StructScopeVisitor : BaseVisitor<StructScope>
    {
        public override StructScope VisitStructScope(DdlParser.StructScopeContext context)
        {
            ConditionalExpression conditionalExpression;
            {
                var expressionContext = context.conditionalExpression();

                if (expressionContext != null)
                {
                    var visitor = new ConditionalExpressionVisitor();

                    conditionalExpression = visitor.VisitConditionalExpression(expressionContext);
                }
                else
                {
                    conditionalExpression = ConditionalExpression.CreateEmpty();
                }
            }

            StructDefinitionContent structContent;
            {
                var defStructContents = context.defStructContents();

                if (defStructContents != null)
                {
                    var visitor = new StructDefinitionContentVisitor();

                    structContent = visitor.VisitDefStructContents(defStructContents);
                }
                else
                {
                    structContent = StructDefinitionContent.CreateEmpty();
                }
            }

            return new StructScope(conditionalExpression, structContent);
        }
    }
}
