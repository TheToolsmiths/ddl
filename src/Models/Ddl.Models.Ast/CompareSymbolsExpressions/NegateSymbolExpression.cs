using TheToolsmiths.Ddl.Models.Ast.Identifiers;

namespace TheToolsmiths.Ddl.Models.Ast.CompareSymbolsExpressions
{
    public class NegateSymbolExpression : IConditionalSymbolExpression
    {
        public NegateSymbolExpression(Identifier identifier)
        {
            this.Identifier = identifier;
        }

        public ConditionalSymbolExpressionType SymbolExpressionType => ConditionalSymbolExpressionType.Negate;

        public Identifier Identifier { get; }
    }
}
