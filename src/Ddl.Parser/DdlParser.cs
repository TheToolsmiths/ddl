using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipelines;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Parser.Containers;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Parser.Parsers;

namespace TheToolsmiths.Ddl.Parser
{
    public class DdlParser
    {
        private readonly DdlLexer lexer;
        private readonly CharSpanKeyedMap<IRootParser> mainParsersMap;

        private DdlParser(
            DdlLexer lexer,
            CharSpanKeyedMap<IRootParser> mainParsersMap)
        {
            this.lexer = lexer;
            this.mainParsersMap = mainParsersMap;
        }

        public static async ValueTask<DdlParser> Create(PipeReader streamReader)
        {
            var arrayBufferWriter = new ArrayBufferWriter<char>();

            var lexer = new DdlLexer(streamReader, arrayBufferWriter);

            await lexer.Initialize();

            var mainParsersMap = MainParserMapBuilder.CreateMainParsersMap();

            return new DdlParser(lexer, mainParsersMap);
        }

        public async IAsyncEnumerable<RootParseResult<IRootContentItem>> ParseFileContents()
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
                var parsers = new ContextParsers();

                var context = new RootParserContext(this.lexer, parsers, this.mainParsersMap);

                var result = await parsers.ParseRootContent(context);

                return result;
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
