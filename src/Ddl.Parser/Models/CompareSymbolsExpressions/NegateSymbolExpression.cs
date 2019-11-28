namespace TheToolsmiths.Ddl.Parser.Models.CompareSymbolsExpressions
{
    public class NegateSymbolExpression : IConditionalSymbolExpression
    {
        public NegateSymbolExpression(Identifier identifier)
        {
            Identifier = identifier;
        }

        public ConditionalSymbolExpressionType SymbolExpressionType => ConditionalSymbolExpressionType.Negate;

        public Identifier Identifier { get; }
    }
}
