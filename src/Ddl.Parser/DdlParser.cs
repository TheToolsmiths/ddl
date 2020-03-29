using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Parser.Containers;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Parser.Parsers;

namespace TheToolsmiths.Ddl.Parser
{
    public class DdlParser
    {
        private readonly ArrayBufferWriter<char> arrayBufferWriter;
        private readonly DdlLexer lexer;
        private readonly CharSpanKeyedMap<IRootParser<RootParserContext>> mainParsersMap;

        private DdlParser(
            DdlLexer lexer,
            ArrayBufferWriter<char> arrayBufferWriter,
            CharSpanKeyedMap<IRootParser<RootParserContext>> mainParsersMap)
        {
            this.lexer = lexer;
            this.arrayBufferWriter = arrayBufferWriter;
            this.mainParsersMap = mainParsersMap;
        }

        public static async ValueTask<DdlParser> Create(PipeReader streamReader)
        {
            var arrayBufferWriter = new ArrayBufferWriter<char>();

            var lexer = new DdlLexer(streamReader, arrayBufferWriter);

            await lexer.Initialize();

            var mainParsersMap = MainParserMapBuilder.CreateMainParsersMap();

            return new DdlParser(lexer, arrayBufferWriter, mainParsersMap);
        }

        public async IAsyncEnumerable<ParseResult<IRootContentItem>> ParseFileContents()
        {
            var parsers = new ContextParsers();

            IReadOnlyList<IAttributeUse> attributeList;
            if (await this.lexer.IsNextOpenAttributeToken())
            {
                var attributeContext = new AttributeParserContext(this.lexer, parsers);
                var result = await parsers.ParseAttributeUseList(attributeContext);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                attributeList = result.Value;
            }
            else
            {
                attributeList = Array.Empty<IAttributeUse>();
            }

            var context = new RootParserContext(this.lexer, attributeList, parsers);

            yield return await this.TryHandleInitialToken(context);
        }

        private async Task<ParseResult<IRootContentItem>> TryHandleInitialToken(RootParserContext context)
        {
            LexerToken token;
            {
                var tokenResult = await this.lexer.TryGetIdentifierToken();

                if (tokenResult.IsError)
                {
                    throw new NotImplementedException();
                }

                token = tokenResult.Token;
            }

            if (this.mainParsersMap.TryGetValue(token.Memory, out var parser) == false)
            {
                throw new NotImplementedException();
            }

            return await parser.ParseRootContent(context).ConfigureAwait(true);
        }
    }
}
