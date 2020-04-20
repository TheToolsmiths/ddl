using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public class FileRootContentParser : IFileRootContentParser
    {
        private readonly IParserMapRegistry parserMap;
        private readonly IRootItemParserContextFactory itemContextFactory;

        public FileRootContentParser(
            IParserMapRegistry parserMap,
            IRootItemParserContextFactory itemContextFactory)
        {
            this.parserMap = parserMap;
            this.itemContextFactory = itemContextFactory;
        }

        public async Task<ParseResult<IReadOnlyList<IRootContentItem>>> ParseRootContentScope(IParserContext context)
        {
            var items = new List<IRootContentItem>();

            while (true)
            {
                if (await context.Lexer.IsNextCloseScopeToken()
                || context.Lexer.HasNextToken == false)
                {
                    break;
                }

                var result = await this.ParseRootContent(context);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                items.Add(result.Value);
            }

            return new ParseResult<IReadOnlyList<IRootContentItem>>(items);
        }

        public async Task<RootParseResult<IRootContentItem>> ParseRootContent(IParserContext context)
        {
            // Skip all possible ; in the root scope
            await SkipAllEndStatementTokens(context);

            var scopeLevel = context.Lexer.LexerScopeLevel;

            // Parse possible attributes
            IReadOnlyList<IAttributeUse> attributes;
            {
                var result = await context.Parsers.ParseAttributeUseList();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                attributes = result.Value;
            }

            {
                var result = await this.TryHandleInitialToken(context, attributes);

                if (result.IsError)
                {
                    await this.SkipNonParseableStruct(context, scopeLevel);
                }

                return result;
            }
        }

        private async Task SkipNonParseableStruct(IParserContext context, LexerScopeLevel scopeLevel)
        {
            var lexer = context.Lexer;

            while (lexer.HasNextToken)
            {
                var result = await lexer.TryGetNextToken();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var token = result.Token;

                if ((token.IsCloseScope() || token.IsEndStatement()) == false)
                {
                    continue;
                }

                if (lexer.LexerScopeLevel == scopeLevel)
                {
                    return;
                }
            }
        }

        private static async Task SkipAllEndStatementTokens(IParserContext context)
        {
            while (await context.Lexer.TrySkipEndStatement())
            {
            }
        }

        private async Task<RootParseResult<IRootContentItem>> TryHandleInitialToken(
            IParserContext context,
            IReadOnlyList<IAttributeUse> attributeList)
        {
            LexerToken token;
            {
                var tokenResult = await context.Lexer.TryGetIdentifierToken();

                if (tokenResult.IsError)
                {
                    throw new NotImplementedException();
                }

                token = tokenResult.Token;
            }

            if (this.parserMap.TryGetParser(token.Memory.Span, out var parser) == false)
            {
                string[] identifiers = { token.Memory.Span.ToString() };
                return RootParseResult<IRootContentItem>.CreateParserHandlerNotFound(identifiers);
            }

            var itemParserContext = this.itemContextFactory.CreateContext(context, attributeList);

            return await parser.ParseRootContent(itemParserContext).ConfigureAwait(true);
        }
    }
}
