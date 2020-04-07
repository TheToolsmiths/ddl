using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers.Implementations
{
    public class FileRootContentParser
    {
        public async Task<ParseResult<IReadOnlyList<IRootContentItem>>> ParseRootContentScope(IRootParserContext context)
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

        public async Task<ParseResult<IRootContentItem>> ParseRootContent(IRootParserContext context)
        {
            // Skip all possible ; in the root scope
            await SkipAllEndStatementTokens(context);

            // Parse possible attributes
            var result = await context.Parsers.ParseAttributeUseList(context);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            return await this.TryHandleInitialToken(context, result.Value);
        }

        private static async Task SkipAllEndStatementTokens(IRootParserContext context)
        {
            while (await context.Lexer.TrySkipEndStatement())
            {
            }
        }

        private async Task<ParseResult<IRootContentItem>> TryHandleInitialToken(
            IRootParserContext context,
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

            if (context.TryGetParserForRootKeyword(token.Memory.Span, out var parser) == false)
            {
                throw new NotImplementedException();
            }

            var itemParserContext = context.CreateItemParserContext(attributeList);

            return await parser.ParseRootContent(itemParserContext).ConfigureAwait(true);
        }
    }
}
