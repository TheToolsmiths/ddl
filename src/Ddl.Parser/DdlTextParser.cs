using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Models.FileContents;

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
            return Task.Run(async () => await ExecuteParseFromFile(path));
        }

        private static async Task<ParseResult<FileContent>> ExecuteParseFromFile(string path)
        {
            try
            {
                var parser = await DdlParserBuilder.CreateParserForPath(path);

                return await ParseFileContents(parser);
            }
            catch (Exception e)
            {
                return ParseResult.FromException<FileContent>(e);
            }
        }

        private static async Task<ParseResult<FileContent>> ParseFileContents(DdlParser parser)
        {
            var items = new List<IRootContentItem>();

            await foreach (var result in parser.ParseFileContents())
            {
                if (result.IsSuccess)
                {
                    items.Add(result.Value!);
                }
            }

            var fileContent = new FileContent(items);

            return ParseResult.FromValue(fileContent);
        }

        ////private static ParseResult<FileContent> ProcessParseCanceledException(ParseCanceledException exception)
        ////{
        ////    string? innerErrorText = null;
        ////    if (exception.InnerException is InputMismatchException inputMismatch)
        ////    {
        ////        var offendingToken = inputMismatch.OffendingToken;
        ////        string offendingTokenText = offendingToken.Text;
        ////        innerErrorText = $"Mismatched input. Unexpected '{offendingTokenText}'" +
        ////                         $" found at {offendingToken.Line}:{offendingToken.Column}";
        ////    }

        ////    string outerErrorText = exception.Message;
        ////    string errorMessage = innerErrorText == null ? outerErrorText : string.Concat(outerErrorText, Environment.NewLine, innerErrorText);

        ////    return ParseResult<FileContent>.FromErrorMessage(errorMessage);
        ////}
    }
}
