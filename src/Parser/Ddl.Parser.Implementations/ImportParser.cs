using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ddl.Common;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Imports;

namespace TheToolsmiths.Ddl.Parser.Implementations
{
    internal class ImportParser : IRootItemParser
    {
        public async ValueTask<RootParseResult<IRootContentItem>> ParseRootContent(IRootItemParserContext context)
        {
            IReadOnlyList<ImportedItem> items;
            {
                LexerToken token;
                {
                    var result = await context.Lexer.TryPeekToken();

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    token = result.Token;
                }

                {
                    Result<IReadOnlyList<ImportedItem>> result;
                    if (token.IsIdentifier() || token.IsAsterisk())
                    {
                        result = await this.ParseSingleImportStatement(context);
                    }
                    else if (token.IsOpenScope())
                    {
                        result = await this.ParseScopedImportStatement(context);
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    items = result.Value;
                }
            }

            string path;
            {
                var parseResult = await this.ParsePathStatement(context);

                if (parseResult.IsError)
                {
                    throw new NotImplementedException();
                }

                path = parseResult.Value;
            }

            var value = new ImportStatement(items, path);

            return RootParseResult<IRootContentItem>.FromResult(value);
        }

        private async Task<Result<string>> ParsePathStatement(IRootItemParserContext context)
        {
            {
                var result = await context.Lexer.TryGetIdentifierToken();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var token = result.Token;

                if (token.Memory.Span.SequenceEqual(ParserIdentifierConstants.From) == false)
                {
                    throw new NotImplementedException();
                }
            }

            string path;
            {
                var result = await context.Lexer.TryGetStringToken();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var token = result.Token;

                path = token.Memory.ToString();
            }

            return Result.FromValue(path);
        }

        private async Task<Result<IReadOnlyList<ImportedItem>>> ParseScopedImportStatement(IRootItemParserContext context)
        {
            if (await context.Lexer.TryConsumeOpenScopeToken() == false)
            {
                throw new NotImplementedException();
            }

            var items = new List<ImportedItem>();
            while (context.Lexer.HasNextToken)
            {
                while (await context.Lexer.TrySkipListSeparatorToken()) { }

                if (await context.Lexer.IsNextCloseScopeToken())
                {
                    break;
                }

                var result = await this.ParseImportedIdentity(context);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var item = result.Value;
                items.Add(item);
            }

            if (await context.Lexer.TryConsumeCloseScopeToken() == false)
            {
                throw new NotImplementedException();
            }

            return Result.FromValue<IReadOnlyList<ImportedItem>>(items);
        }

        private async Task<Result<IReadOnlyList<ImportedItem>>> ParseSingleImportStatement(IRootItemParserContext context)
        {
            var result = await this.ParseImportedIdentity(context);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var item = result.Value;

            var items = new List<ImportedItem> { item };
            return Result.FromValue<IReadOnlyList<ImportedItem>>(items);
        }

        private async Task<Result<ImportedItem>> ParseImportedIdentity(IRootItemParserContext context)
        {
            Identifier? identifier;
            bool isAllImport;
            {
                var result = await context.Lexer.TryGetNextToken();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var token = result.Token;

                if (token.IsIdentifier())
                {
                    identifier = new Identifier(token.Memory.ToString());
                    isAllImport = false;
                }
                else if (token.IsAsterisk())
                {
                    identifier = null;
                    isAllImport = true;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            var aliasIdentifier = Identifier.Empty;
            {
                var result = await context.Lexer.TryPeekIdentifierToken();

                if (result.HasToken)
                {
                    var token = result.Token;
                    if (token.Memory.Span.SequenceEqual(ParserIdentifierConstants.As))
                    {
                        context.Lexer.PopToken();

                        var aliasResult = await context.Lexer.TryGetIdentifierToken();

                        if (aliasResult.IsError)
                        {
                            throw new NotImplementedException();
                        }

                        var aliasToken = aliasResult.Token;

                        aliasIdentifier = new Identifier(aliasToken.Memory.ToString());
                    }
                }
            }

            ImportedItem item;
            if (isAllImport)
            {
                item = ImportedItem.CreateAll(aliasIdentifier);
            }
            else
            {
                if (identifier == null)
                {
                    throw new NotImplementedException();
                }

                item = ImportedItem.Create(identifier, aliasIdentifier);
            }

            return Result.FromValue(item);
        }
    }
}
