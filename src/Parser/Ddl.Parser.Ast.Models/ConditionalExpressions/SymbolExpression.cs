using TheToolsmiths.Ddl.Parser.Ast.Models.CompareSymbolsExpressions;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ConditionalExpressions
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
