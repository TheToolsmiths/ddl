using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public class ScopeContentParser : IScopeContentParser
    {
        private readonly ILogger<ScopeContentParser> log;
        private readonly IRootParserResolver parserResolver;
        private readonly IRootItemParserContextFactory itemContextFactory;
        private readonly IRootScopeParserContextFactory scopeContextFactory;

        public ScopeContentParser(
            ILogger<ScopeContentParser> log,
            IRootParserResolver parserResolver,
            IRootItemParserContextFactory itemContextFactory,
            IRootScopeParserContextFactory scopeContextFactory)
        {
            this.log = log;
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
                    this.HandleParseRootContentError(result);
                }
            }

            var scopeContent = scopeContext.CreateScopeContent();

            return Result.FromValue(scopeContent);
        }

        private async Task<RootEntryParseResult> ParseRootContent(
            IParserContext context,
            ScopeContentParseContext scopeContext)
        {
            // Skip all possible ; in the root scope
            await SkipAllEndStatementTokens(context);

            var scopeLevel = context.Lexer.LexerScopeLevel;

            // Parse possible attributes
            AstAttributeUseCollection attributes;
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

        private async Task<RootEntryParseResult> TryHandleInitialToken(
            IParserContext context,
            ScopeContentParseContext scopeContext,
            AstAttributeUseCollection attributeList)
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

                if (result is RootItemParseSuccess success)
                {
                    scopeContext.Items.Add(success.Value);
                }

                return result;
            }

            if (this.parserResolver.TryResolveScopeParser(token.Memory.Span, out var scopeParser))
            {
                var itemParserContext = this.scopeContextFactory.CreateContext(context, attributeList);

                var result = await scopeParser.ParseRootScope(itemParserContext).ConfigureAwait(true);

                if (result is RootScopeParseSuccess success)
                {
                    scopeContext.Scopes.Add(success.Value);
                }

                return result;
            }

            string[] identifiers = { token.Memory.Span.ToString() };

            return RootItemParseResult.CreateParserHandlerNotFound(identifiers);
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

        private void HandleParseRootContentError(RootEntryParseResult result)
        {
            if (result.IsSuccess)
            {
                throw new InvalidOperationException();
            }

            switch (result)
            {
                case IParserNotFoundParseError parserNotFoundError:
                    this.log.LogWarning("Parser failed to find root parser for '{identifiers}'", parserNotFoundError.ParserLookupIdentifiers);
                    break;

                case RootItemParseError rootItemParseError:
                    this.log.LogWarning("Root item parser failed. Error: {message}", rootItemParseError.ErrorMessage);
                    break;

                case RootScopeParseError rootScopeParseError:
                    this.log.LogWarning("Root scope parser failed. Error: {message}", rootScopeParseError.ErrorMessage);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(result));
            }
        }
    }
}
