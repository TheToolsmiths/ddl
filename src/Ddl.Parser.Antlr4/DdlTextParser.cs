using System;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Parser.Utils;
using TheToolsmiths.Ddl.Parser.Visitors;

namespace TheToolsmiths.Ddl.Parser
{
    public static class DdlTextParser
    {
        public static Task<ParseResult<FileContent>> ParseFromString(string contents)
        {
            throw new NotImplementedException();
        }

        public static Task<ParseResult<FileContent>> ParseFromFile(string path)
        {
            return Task.Run(() => ExecuteParseFromFile(path));
        }

        private static ParseResult<FileContent> ExecuteParseFromFile(string path)
        {
            try
            {
                var parser = ParserUtils.CreateParserFromPath(path);

                var visitor = new FileContentVisitor();

                var fileContentsContext = parser.fileContents();

                var fileContents = visitor.VisitFileContents(fileContentsContext);

                return ParseResult<FileContent>.FromValue(fileContents);
            }
            catch (ParseCanceledException e)
            {
                return ProcessParseCanceledException(e);
            }
            catch (Exception e)
            {
                return ParseResult<FileContent>.FromException(e);
            }
        }

        private static ParseResult<FileContent> ProcessParseCanceledException(ParseCanceledException exception)
        {
            string? innerErrorText = null;
            if (exception.InnerException is InputMismatchException inputMismatch)
            {
                var offendingToken = inputMismatch.OffendingToken;
                string offendingTokenText = offendingToken.Text;
                innerErrorText = $"Mismatched input. Unexpected '{offendingTokenText}'" +
                                 $" found at {offendingToken.Line}:{offendingToken.Column}";
            }

            string outerErrorText = exception.Message;
            string errorMessage = innerErrorText == null ? outerErrorText : string.Concat(outerErrorText, Environment.NewLine, innerErrorText);

            return ParseResult<FileContent>.FromErrorMessage(errorMessage);
        }
    }
}
