using TheToolsmiths.Ddl.Parser.Models.Operators;

namespace TheToolsmiths.Ddl.Parser.Models.CompareSymbolsExpressions
{
    public class CompareSymbolExpression : IConditionalSymbolExpression
    {
        public CompareSymbolExpression(
            Identifier identifier,
            IEqualityComparerOperator comparer,
            string literalValue)
        {
            Identifier = identifier;
            Comparer = comparer;
            LiteralValue = literalValue;
        }

        public ConditionalSymbolExpressionType SymbolExpressionType => ConditionalSymbolExpressionType.Compare;

        public Identifier Identifier { get; }

        public IEqualityComparerOperator Comparer { get; }

        public string LiteralValue { get; }
    }
}
