using System.IO;
using Antlr4.Runtime;
using TheToolsmiths.Ddl.Parser.Tests.Listeners;

namespace TheToolsmiths.Ddl.Parser.Tests.Utils
{
    public static class FileParserUtils
    {
        public static DdlParser CreateParserFromPath(string filePath)
        {
            filePath = Path.Join(PathConstants.ExamplesFolder, filePath);

            var inputStream = CharStreams.fromPath(filePath);

            var lexer = new DdlLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(lexer);

            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(new AssertLexerErrorListener(filePath));

            var parser = new DdlParser(commonTokenStream)
            {
                BuildParseTree = true
            };

            parser.RemoveParseListeners();
            parser.AddErrorListener(new AssertErrorListener(filePath));

            return parser;
        }
    }
}
