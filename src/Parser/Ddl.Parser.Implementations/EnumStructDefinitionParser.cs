using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.Models.Enums;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Structs;
using TheToolsmiths.Ddl.Parser.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Implementations
{
    internal class EnumStructDefinitionParser : IRootItemParser
    {
        public async ValueTask<RootParseResult<IRootContentItem>> ParseRootContent(IRootItemParserContext context)
        {
            ITypeName typeName;
            {
                var result = await context.Parsers.ParseTypeName();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                typeName = result.Value;
            }

            if (await context.Lexer.TryConsumeOpenScopeToken() == false)
            {
                throw new NotImplementedException();
            }

            EnumStructDefinitionContent content;
            {
                var parseResult = await this.ParseBlockContent(context);

                if (parseResult.IsError)
                {
                    throw new NotImplementedException();
                }

                content = parseResult.Value;
            }

            if (await context.Lexer.TryConsumeCloseScopeToken() == false)
            {
                throw new NotImplementedException();
            }

            var value = new EnumStructDefinition(typeName, content, context.AttributeList);

            return RootParseResult<IRootContentItem>.FromResult(value);
        }

        private async Task<ParseResult<EnumStructDefinitionContent>> ParseBlockContent(IRootItemParserContext context)
        {
            var items = new List<IEnumStructDefinitionItem>();

            while (true)
            {
                Identifier identifier;

                // Parse enum struct Identifier
                {
                    var result = await context.Lexer.TryPeekToken();

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    var token = result.Token;

                    if (token.Kind == LexerTokenKind.CloseScope)
                    {
                        break;
                    }

                    if (token.Kind != LexerTokenKind.Identifier)
                    {
                        throw new NotImplementedException();
                    }

                    context.Lexer.PopToken();

                    identifier = new Identifier(token.Memory.ToString());
                }

                // Parse Variant OpenScope token
                {
                    var result = await context.Lexer.TryGetNextToken();

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    var token = result.Token;

                    if (token.Kind == LexerTokenKind.ListSeparator)
                    {
                        AddEmptyVariant(identifier);
                        continue;
                    }

                    if (token.Kind != LexerTokenKind.OpenScope)
                    {
                        throw new NotImplementedException();
                    }
                }

                {
                    var result = await context.Parsers.ParseStructDefinitionContentParser();

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    var content = result.Value;

                    AddVariantWithContent(identifier, content);
                }

                {
                    if (await context.Lexer.TryConsumeCloseScopeToken() == false)
                    {
                        throw new NotImplementedException();
                    }

                    await context.Lexer.TryConsumeListSeparatorToken();
                }
            }

            void AddEmptyVariant(Identifier name)
            {
                var content = StructDefinitionContent.CreateEmpty();

                var item = new EnumStructVariantDefinition(name, content);

                items.Add(item);
            }

            void AddVariantWithContent(Identifier name, StructDefinitionContent content)
            {
                var item = new EnumStructVariantDefinition(name, content);

                items.Add(item);
            }

            var value = new EnumStructDefinitionContent(items);

            return new ParseResult<EnumStructDefinitionContent>(value);
        }
    }
}
