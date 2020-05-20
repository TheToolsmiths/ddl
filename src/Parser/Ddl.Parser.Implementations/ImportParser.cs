using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ddl.Common;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Imports;

namespace TheToolsmiths.Ddl.Parser.Implementations
{
    internal class ImportParser : IRootItemParser
    {
        public async ValueTask<RootParseResult<IRootItem>> ParseRootContent(IRootItemParserContext context)
        {
            bool isRootedType = await context.Lexer.TryConsumeNamespaceSeparatorToken();

            ImportItem importItem;
            {
                var result = await this.ParseImportPath(context).ConfigureAwait(false);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                importItem = result.Value;
            }

            if (await context.Lexer.TryConsumeEndStatementToken() == false)
            {
                throw new NotImplementedException();
            }

            var importRoot = isRootedType ? ImportRoot.CreateWithChildItem(importItem) : importItem;

            var importStatement = new ImportStatement(importRoot);
            return RootParseResult.FromResult<IRootItem>(importStatement);
        }

        private async Task<Result<ImportItem>> ParseImportPath(IRootItemParserContext context)
        {
            var identifiers = new List<Identifier>();

            // Parse all `identifier::` in the import path
            while (true)
            {
                var result = await context.Lexer.TryGetIdentifierToken();

                if (result.IsError)
                {
                    break;
                }

                var identifierToken = result.Token;

                Identifier identifier = Identifier.FromString(identifierToken.Memory.ToString());
                identifiers.Add(identifier);

                if (await context.Lexer.TryConsumeNamespaceSeparatorToken() == false)
                {
                    break;
                }
            }

            // If its starting a path group
            // e.g. `{ foo, bar }`
            if (await context.Lexer.IsNextOpenScopeToken())
            {
                // Parse group
                var result = await this.ParseImportGroup(context).ConfigureAwait(false);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                // Build the path with the existing identifier list and the parsed group;
                var scope = result.Value;
                var value = ImportItemBuilder.CreateFromIdentifierListWithGroup(identifiers, scope);

                return Result.FromValue(value);
            }

            // If import path does not end with *
            // e.g. `std::bar` `std::bar as Alias`
            {
                // If statement has an alias
                // e.g. `std::bar as Alias`
                if (await this.TryConsumeAsIdentifier(context))
                {
                    var result = await context.Lexer.TryGetIdentifierToken();

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    var resultToken = result.Token;

                    var aliasIdentifier = new Identifier(resultToken.Memory.ToString());

                    var value = ImportItemBuilder.CreateAliasFromIdentifierList(identifiers, aliasIdentifier);

                    return Result.FromValue(value);
                }

                {
                    var value = ImportItemBuilder.CreateFromIdentifierList(identifiers);

                    return Result.FromValue(value);
                }
            }
        }

        private async Task<bool> TryConsumeAsIdentifier(IRootItemParserContext context)
        {
            var tokenResult = await context.Lexer.TryPeekIdentifierToken();

            if (tokenResult.HasToken)
            {
                if (tokenResult.Token.Memory.Span.SequenceEqual(ParserIdentifierConstants.As))
                {
                    context.Lexer.PopToken();
                    return true;
                }
            }

            return false;
        }

        private async Task<Result<ImportGroup>> ParseImportGroup(IRootItemParserContext context)
        {
            if (await context.Lexer.TryConsumeOpenScopeToken() == false)
            {
                throw new NotImplementedException();
            }

            var items = new List<ImportItem>();

            while (true)
            {
                var result = await this.ParseImportPath(context).ConfigureAwait(false);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var importItem = result.Value;

                if (await context.Lexer.TryConsumeListSeparatorToken() == false)
                {
                    break;
                }

                items.Add(importItem);
            }

            if (await context.Lexer.TryConsumeCloseScopeToken() == false)
            {
                throw new NotImplementedException();
            }

            var importGroup = ImportGroup.Create(items);

            return Result.FromValue(importGroup);
        }
    }
}
