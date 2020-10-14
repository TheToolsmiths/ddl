using TheToolsmiths.Ddl.Models.Ast.CompareSymbolsExpressions;

namespace TheToolsmiths.Ddl.Models.Ast.ConditionalExpressions
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
