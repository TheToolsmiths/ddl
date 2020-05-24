using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.CompareSymbolsExpressions
{
    public class IdentifierSymbolExpression : IConditionalSymbolExpression
    {
        public IdentifierSymbolExpression(Identifier identifier)
        {
            this.Identifier = identifier;
        }

        public ConditionalSymbolExpressionType SymbolExpressionType => ConditionalSymbolExpressionType.Identifier;

        public Identifier Identifier { get; }
    }
}
