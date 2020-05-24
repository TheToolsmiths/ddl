using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.CompareSymbolsExpressions
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
