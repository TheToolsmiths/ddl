using TheToolsmiths.Ddl.Parser.Models.Identifiers;
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
            this.Identifier = identifier;
            this.Comparer = comparer;
            this.LiteralValue = literalValue;
        }

        public ConditionalSymbolExpressionType SymbolExpressionType => ConditionalSymbolExpressionType.Compare;

        public Identifier Identifier { get; }

        public IEqualityComparerOperator Comparer { get; }

        public string LiteralValue { get; }
    }
}
