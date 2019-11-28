namespace TheToolsmiths.Ddl.Parser.Models.CompareSymbolsExpressions
{
    public class IdentifierSymbolExpression : IConditionalSymbolExpression
    {
        public IdentifierSymbolExpression(Identifier identifier)
        {
            Identifier = identifier;
        }

        public ConditionalSymbolExpressionType SymbolExpressionType => ConditionalSymbolExpressionType.Identifier;

        public Identifier Identifier { get; }
    }
}
