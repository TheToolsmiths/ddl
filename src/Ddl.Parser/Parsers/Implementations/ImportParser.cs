using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Models.Identifiers;
using TheToolsmiths.Ddl.Models.Imports;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers.Implementations
{
    internal class ImportParser : IRootParser
    {
        public async ValueTask<RootParseResult<IRootContentItem>> ParseRootContent(IRootItemParserContext context)
        {
            IReadOnlyList<ImportedItem> items;
            {
                var result = await context.Lexer.TryPeekToken();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var token = result.Token;

                ParseResult<IReadOnlyList<ImportedItem>> parseResult;
                if (token.IsIdentifier() || token.IsAsterisk())
                {
                    parseResult = await this.ParseSingleImportStatement(context);
                }
                else if (token.IsOpenScope())
                {
                    parseResult = await this.ParseScopedImportStatement(context);
                }
                else
                {
                    throw new NotImplementedException();
                }

                if (parseResult.IsError)
                {
                    throw new NotImplementedException();
                }

                items = parseResult.Value;
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

        private async Task<ParseResult<string>> ParsePathStatement(IRootItemParserContext context)
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

            return new ParseResult<string>(value: path);
        }

        private async Task<ParseResult<IReadOnlyList<ImportedItem>>> ParseScopedImportStatement(IRootItemParserContext context)
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

            return new ParseResult<IReadOnlyList<ImportedItem>>(items);
        }

        private async Task<ParseResult<IReadOnlyList<ImportedItem>>> ParseSingleImportStatement(IRootItemParserContext context)
        {
            var result = await this.ParseImportedIdentity(context);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var item = result.Value;

            var items = new List<ImportedItem> { item };
            return new ParseResult<IReadOnlyList<ImportedItem>>(items);
        }

        private async Task<ParseResult<ImportedItem>> ParseImportedIdentity(IRootItemParserContext context)
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

            return new ParseResult<ImportedItem>(item);
        }
    }
}
