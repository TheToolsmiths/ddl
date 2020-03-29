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

        public static async Task<ParseResult<FileContent>> ParseFromFile(string path)
        {
            return await ExecuteParseFromFile(path).ConfigureAwait(false);
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
    }
}
