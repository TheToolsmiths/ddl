using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Models.FileContents;
using TheToolsmiths.Ddl.Parser.Shared;
using TheToolsmiths.Ddl.Parser.Shared.Contexts;

namespace TheToolsmiths.Ddl.Parser
{
    public class DdlParser
    {
        private readonly IDdlLexer lexer;
        private readonly ILogger<DdlParser> log;
        private readonly IFileRootContentParser rootContentParser;
        private readonly IParserContext parserContext;

        public DdlParser(
            ILogger<DdlParser> log,
            IDdlLexer lexer,
            IFileRootContentParser rootContentParser,
            IParserContext parserContext)
        {
            this.log = log;
            this.lexer = lexer;
            this.rootContentParser = rootContentParser;
            this.parserContext = parserContext;
        }

        public async Task<ParseResult<FileContent>> ParseFileContents()
        {
            var items = new List<IRootContentItem>();

            await foreach (var result in this.ParseAllFileContents())
            {
                if (result.IsSuccess)
                {
                    items.Add(result.Value!);
                }
            }

            var fileContent = new FileContent(items);

            return ParseResult.FromValue(fileContent);
        }

        private async IAsyncEnumerable<RootParseResult<IRootContentItem>> ParseAllFileContents()
        {
            while (this.lexer.HasNextToken)
            {
                if (await this.lexer.TryParseTokens() == false)
                {
                    yield break;
                }

                yield return await this.ParseFileContent();
            }
        }

        private async Task<RootParseResult<IRootContentItem>> ParseFileContent()
        {
            try
            {
                return await this.rootContentParser.ParseRootContent(parserContext);
            }
            catch (Exception e)
            {
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }

                return RootParseResult<IRootContentItem>.FromError(e.ToString());
            }
        }
    }
}
