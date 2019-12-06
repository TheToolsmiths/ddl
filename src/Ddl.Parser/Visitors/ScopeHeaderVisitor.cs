using TheToolsmiths.Ddl.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class ScopeHeaderVisitor : BaseVisitor<ConditionalExpression>
    {
        public override ConditionalExpression VisitScopeHeader(DdlParser.ScopeHeaderContext context)
        {
            ConditionalExpression conditionalExpression;

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

            return conditionalExpression;
        }
    }
}
