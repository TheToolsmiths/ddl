using System.IO;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Parser.Tests.Utils;

namespace TheToolsmiths.Ddl.Lexer.Tests.Utils
{
    public static class FileLexerUtils
    {
        public static Task<DdlLexer> CreateLexerFromPath(string filePath)
        {
            filePath = Path.Join(PathConstants.ExamplesFolder, filePath);

            return DdlTextLexer.LexerFromFile(filePath);
        }
    }
}
