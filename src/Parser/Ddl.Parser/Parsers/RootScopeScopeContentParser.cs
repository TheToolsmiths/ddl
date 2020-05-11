using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ddl.Common;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Entries;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public class RootScopeScopeContentParser : IRootScopeContentParser
    {
        private readonly IRootParserResolver parserResolver;
        private readonly IRootItemParserContextFactory itemContextFactory;
        private readonly IRootScopeParserContextFactory scopeContextFactory;

        public RootScopeScopeContentParser(
            IRootParserResolver parserResolver,
            IRootItemParserContextFactory itemContextFactory,
            IRootScopeParserContextFactory scopeContextFactory)
        {
            this.itemContextFactory = itemContextFactory;
            this.scopeContextFactory = scopeContextFactory;
            this.parserResolver = parserResolver;
        }

        public async Task<Result<RootScopeContent>> ParseRootScopeContent(IParserContext context)
        {
            var items = new List<IRootContentEntry>();

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

            var scopeContent = new RootScopeContent(items);

            return Result.FromValue(scopeContent);
        }

        private async Task<RootParseResult<IRootContentEntry>> ParseRootContent(IParserContext context)
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

        private async Task<RootParseResult<IRootContentEntry>> TryHandleInitialToken(
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

            if (this.parserResolver.TryResolveItemParser(token.Memory.Span, out var itemParser))
            {
                var itemParserContext = this.itemContextFactory.CreateContext(context, attributeList);

                return (await itemParser.ParseRootContent(itemParserContext).ConfigureAwait(true)).As<IRootContentEntry>();
            }

            if (this.parserResolver.TryResolveScopeParser(token.Memory.Span, out var scopeParser))
            {
                var itemParserContext = this.scopeContextFactory.CreateContext(context, attributeList);

                return (await scopeParser.ParseRootScope(itemParserContext).ConfigureAwait(true)).As<IRootContentEntry>();
            }

            string[] identifiers = { token.Memory.Span.ToString() };
            return RootParseResult<IRootContentEntry>.CreateParserHandlerNotFound(identifiers);
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
    }
}
