using System.IO;
using Antlr4.Runtime;

namespace TheToolsmiths.Ddl.Parser.Tests.Utils
{
    public static class FileParserUtils
    {
        public static DdlParser CreateParserFromPath(string path)
        {
            path = Path.Join(PathConstants.ExamplesFolder, path);

            var inputStream = CharStreams.fromPath(path);
            var lexer = new DdlLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(lexer);
            var parser = new DdlParser(commonTokenStream)
            {
                BuildParseTree = true
            };

            return parser;
        }
    }
}
