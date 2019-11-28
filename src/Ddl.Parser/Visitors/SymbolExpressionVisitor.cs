using Antlr4.Runtime.Tree;
using TheToolsmiths.Ddl.Parser.Models.CompareSymbolsExpressions;

namespace TheToolsmiths.Ddl.Parser.Visitors
{
    public class ConditionalSymbolExpressionVisitor : BaseVisitor<IConditionalSymbolExpression>
    {
        public IConditionalSymbolExpression VisitConditionalSymbolExpression(
            DdlParser.ConditionalSymbolExpressionContext expressionContext)
        {
            var listener = new ConditionalSymbolExpressionListener();

            ParseTreeWalker.Default.Walk(listener, expressionContext);

            return listener.GetSymbolExpression();
        }
    }
}
