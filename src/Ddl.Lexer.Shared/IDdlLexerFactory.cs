using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;

namespace TheToolsmiths.Ddl.Parser
{
    public interface IDdlLexerFactory
    {
        Task<IDdlLexer> CreateForFile(string path);
    }
}
