using TheToolsmiths.Ddl.Parser.Models.CompareSymbolsExpressions;

namespace TheToolsmiths.Ddl.Parser.Models.ConditionalExpressions
{
    public class SymbolExpression : IConditionalExpressionElement
    {
        public SymbolExpression(IConditionalSymbolExpression expression)
        {
            this.Expression = expression;
        }

        public ConditionalExpressionElementType ElementType => ConditionalExpressionElementType.Symbol;

        public IConditionalSymbolExpression Expression { get; }
    }
}
