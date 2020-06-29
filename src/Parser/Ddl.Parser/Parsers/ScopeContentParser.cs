using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Entries;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public class ScopeContentParser : IScopeContentParser
    {
        private readonly IRootParserResolver parserResolver;
        private readonly IRootItemParserContextFactory itemContextFactory;
        private readonly IRootScopeParserContextFactory scopeContextFactory;

        public ScopeContentParser(
            IRootParserResolver parserResolver,
            IRootItemParserContextFactory itemContextFactory,
            IRootScopeParserContextFactory scopeContextFactory)
        {
            this.itemContextFactory = itemContextFactory;
            this.scopeContextFactory = scopeContextFactory;
            this.parserResolver = parserResolver;
        }

        public async Task<Result<AstScopeContent>> ParseRootScopeContent(IParserContext context)
        {
            var scopeContext = new ScopeContentParseContext();

            while (true)
            {
                if (await context.Lexer.IsNextCloseScopeToken()
                || context.Lexer.HasNextToken == false)
                {
                    break;
                }

                var result = await this.ParseRootContent(context, scopeContext);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            var scopeContent = scopeContext.CreateScopeContent();

            return Result.FromValue(scopeContent);
        }

        private async Task<RootParseResult> ParseRootContent(
            IParserContext context,
            ScopeContentParseContext scopeContext)
        {
            // Skip all possible ; in the root scope
            await SkipAllEndStatementTokens(context);

            var scopeLevel = context.Lexer.LexerScopeLevel;

            // Parse possible attributes
            IReadOnlyList<IAstAttributeUse> attributes;
            {
                var result = await context.Parsers.ParseAttributeUseList();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                attributes = result.Value;
            }

            {
                var result = await this.TryHandleInitialToken(context, scopeContext, attributes);

                if (result.IsError)
                {
                    await this.SkipNonParseableStruct(context, scopeLevel);
                }

                return result;
            }
        }

        private async Task<RootParseResult> TryHandleInitialToken(
            IParserContext context,
            ScopeContentParseContext scopeContext,
            IReadOnlyList<IAstAttributeUse> attributeList)
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

                var result = await itemParser.ParseRootContent(itemParserContext).ConfigureAwait(true);

                if (result.IsError)
                {
                    return result;
                }

                scopeContext.Items.Add(result.Value);

                return result;
            }

            if (this.parserResolver.TryResolveScopeParser(token.Memory.Span, out var scopeParser))
            {
                var itemParserContext = this.scopeContextFactory.CreateContext(context, attributeList);

                var result = await scopeParser.ParseRootScope(itemParserContext).ConfigureAwait(true);

                if (result.IsError)
                {
                    return result;
                }

                scopeContext.Scopes.Add(result.Value);

                return result;
            }

            string[] identifiers = { token.Memory.Span.ToString() };
            return RootParseResult.CreateParserHandlerNotFound<IAstRootEntry>(identifiers);
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
