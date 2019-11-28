using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using TheToolsmiths.Ddl.Parser.Tests.AssertExceptions;

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

    public class AssertErrorListener : IAntlrErrorListener<IToken>
    {
        public AssertErrorListener(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; }

        public void SyntaxError(
            TextWriter output,
            IRecognizer recognizer,
            IToken offendingSymbol,
            int line,
            int charPositionInLine,
            string msg,
            RecognitionException e)
        {
            throw new AssertLexerException($"Lexer error in file '{FilePath}' at line '{line}' in pos '{charPositionInLine}'.\n{msg}");
        }
    }

    public class AssertLexerErrorListener : IAntlrErrorListener<int>
    {
        public AssertLexerErrorListener(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; }

        public void SyntaxError(
            TextWriter output,
            IRecognizer recognizer,
            int offendingSymbol,
            int line,
            int charPositionInLine,
            string msg,
            RecognitionException e)
        {
            throw new AssertParserException($"Parser error in file '{FilePath}' at line '{line}' in pos '{charPositionInLine}'.\n{msg}");
        }
    }
}
