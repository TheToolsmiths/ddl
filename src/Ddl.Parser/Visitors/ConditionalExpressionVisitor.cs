using Antlr4.Runtime.Tree;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class ConditionalExpressionVisitor : BaseVisitor<ConditionalExpression>
    {
        public ConditionalExpression VisitConditionalExpression(
            DdlParser.ConditionalExpressionContext expressionContext)
        {
            var listener = new ConditionalExpressionListener();

            ParseTreeWalker.Default.Walk(listener, expressionContext);

            return listener.GetExpression();
        }
    }
}
