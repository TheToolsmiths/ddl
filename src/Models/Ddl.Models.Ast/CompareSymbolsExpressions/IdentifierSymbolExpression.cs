using TheToolsmiths.Ddl.Models.Ast.Identifiers;

namespace TheToolsmiths.Ddl.Models.Ast.CompareSymbolsExpressions
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
