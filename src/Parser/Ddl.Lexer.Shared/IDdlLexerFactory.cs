using System.Threading.Tasks;

namespace TheToolsmiths.Ddl.Lexer
{
    public interface IDdlLexerFactory
    {
        Task<IDdlLexer> CreateForFile(string path);
    }
}
