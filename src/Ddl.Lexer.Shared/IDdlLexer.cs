using System.Threading.Tasks;

namespace TheToolsmiths.Ddl.Lexer
{
    public interface IDdlLexer : ILexer
    {
        Task<bool> TryParseTokens();
    }
}
