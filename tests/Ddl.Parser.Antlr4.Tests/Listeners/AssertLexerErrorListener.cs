using System.IO;
using Antlr4.Runtime;
using TheToolsmiths.Ddl.Parser.Tests.AssertExceptions;

namespace TheToolsmiths.Ddl.Parser.Tests.Listeners
{
    public class AssertLexerErrorListener : IAntlrErrorListener<int>
    {
        private readonly string filePath;

        public AssertLexerErrorListener(string filePath)
        {
            this.filePath = filePath;
        }

        public void SyntaxError(
            TextWriter output,
            IRecognizer recognizer,
            int offendingSymbol,
            int line,
            int charPositionInLine,
            string msg,
            RecognitionException e)
        {
            throw new AssertParserException($"Parser error in file '{this.filePath}' at line '{line}' in pos '{charPositionInLine}'.\n{msg}");
        }
    }
}
