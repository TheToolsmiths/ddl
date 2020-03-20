using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Parser.Containers;
using TheToolsmiths.Ddl.Parser.Lexers;
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

            var mainParsersMap = CreateMainParsersMap();

            return new DdlParser(lexer, arrayBufferWriter, mainParsersMap);
        }

        private static CharSpanKeyedMap<IRootParser<RootParserContext>> CreateMainParsersMap()
        {
            var definitionsParser = new DefinitionsParser
            {
                {ParserIdentifierConstants.Struct, new StructDefinitionParser()},
                {ParserIdentifierConstants.Enum, new EnumDefinitionDisambiguatorParser()}
            };

            return new CharSpanKeyedMap<IRootParser<RootParserContext>> { { ParserIdentifierConstants.Definition, definitionsParser } };
        }

        public async IAsyncEnumerable<ParseResult<IRootContentItem>> ParseFileContents()
        {
            var tokenResult = await this.lexer.TryGetNextToken();

            if (tokenResult.IsError)
            {
                yield break;
            }

            var token = tokenResult.Token;

            yield return await this.TryHandleInitialToken(token);
        }

        private async Task<ParseResult<IRootContentItem>> TryHandleInitialToken(LexerToken token)
        {
            // Check if token is Attribute Open symbol

            // Check if token is known identifier
            if (token.Kind != LexerTokenKind.Identifier)
            {
                throw new NotImplementedException();
            }

            if (this.mainParsersMap.TryGetValue(token.Memory, out var parser) == false)
            {
                throw new NotImplementedException();
            }

            var parsers = new ContextParsers();
            var context = new RootParserContext(this.lexer, parsers);

            return await parser.ParseRootContent(context);
        }
    }
}
