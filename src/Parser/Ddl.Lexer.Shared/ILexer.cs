using System.Threading.Tasks;

namespace TheToolsmiths.Ddl.Lexer
{
    public interface ILexer
    {
        ValueTask<TokenResult> TryGetNextToken();

        ValueTask<TokenResult> TryPeekToken();

        ValueTask<DoubleTokenResult> TryPeekNextTwoToken();

        void PopToken();

        bool HasNextToken { get; }

        LexerScopeLevel LexerScopeLevel { get; }
    }
}
