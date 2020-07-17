using TheToolsmiths.Ddl.Parser.Ast.Models.CompareSymbolsExpressions;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ConditionalExpressions
{
    public class SymbolExpression : IAstConditionalExpressionElement
    {
        public SymbolExpression(IConditionalSymbolExpression expression)
        {
            this.Expression = expression;
        }

        public AstConditionalExpressionElementType ElementType => AstConditionalExpressionElementType.Symbol;

        public IConditionalSymbolExpression Expression { get; }
    }
}
