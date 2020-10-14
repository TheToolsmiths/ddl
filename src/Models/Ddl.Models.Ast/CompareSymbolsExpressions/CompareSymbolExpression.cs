using TheToolsmiths.Ddl.Models.Ast.Identifiers;
using TheToolsmiths.Ddl.Models.Ast.Operators;

namespace TheToolsmiths.Ddl.Models.Ast.CompareSymbolsExpressions
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
