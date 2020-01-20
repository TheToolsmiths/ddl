using TheToolsmiths.Ddl.Models.Identifiers;

namespace TheToolsmiths.Ddl.Models.CompareSymbolsExpressions
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
