using System.IO;
using Antlr4.Runtime;
using TheToolsmiths.Ddl.Parser.Tests.AssertExceptions;

namespace TheToolsmiths.Ddl.Parser.Tests.Listeners
{
    public class AssertErrorListener : IAntlrErrorListener<IToken>
    {
        private readonly string filePath;

        public AssertErrorListener(string filePath)
        {
            this.filePath = filePath;
        }

        public void SyntaxError(
            TextWriter output,
            IRecognizer recognizer,
            IToken offendingSymbol,
            int line,
            int charPositionInLine,
            string msg,
            RecognitionException e)
        {
            throw new AssertLexerException($"Lexer error in file '{filePath}' at line '{line}' in pos '{charPositionInLine}'.\n{msg}");
        }
    }
}
