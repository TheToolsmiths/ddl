using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Models.Enums;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Models.Identifiers;
using TheToolsmiths.Ddl.Models.Literals;
using TheToolsmiths.Ddl.Models.Types;
using TheToolsmiths.Ddl.Parser.Shared;
using TheToolsmiths.Ddl.Parser.Shared.Contexts;

namespace TheToolsmiths.Ddl.Parser.Implementations
{
    internal class EnumDefinitionParser : IRootItemParser
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

            EnumDefinitionContent content;
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

            var value = new EnumDefinition(typeName, content, context.AttributeList);

            return RootParseResult<IRootContentItem>.FromResult(value);
        }

        private async Task<ParseResult<EnumDefinitionContent>> ParseBlockContent(IRootItemParserContext context)
        {
            var items = new List<IEnumDefinitionItem>();

            while (true)
            {
                if (await context.Lexer.IsNextCloseScopeToken())
                {
                    break;
                }

                await ParseEnumDefinition();

                if (await context.Lexer.TryConsumeListSeparatorToken())
                {
                    continue;
                }

                if (await context.Lexer.IsNextCloseScopeToken())
                {
                    break;
                }

                throw new NotImplementedException();
            }

            var value = new EnumDefinitionContent(items);

            return new ParseResult<EnumDefinitionContent>(value);

            async Task ParseEnumDefinition()
            {
                LexerToken token;
                {
                    var result = await context.Lexer.TryGetIdentifierToken();

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    token = result.Token;
                }

                var identifier = new Identifier(token.Memory.ToString());

                LiteralValue literalValue;
                if (await context.Lexer.TryConsumeFieldInitializationToken())
                {
                    var parseResult = await context.Parsers.ParseLiteralValue();

                    if (parseResult.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    literalValue = parseResult.Value;
                }
                else
                {
                    literalValue = LiteralValue.CreateEmpty();
                }

                var item = new EnumDefinitionConstantDefinition(identifier, literalValue);

                items.Add(item);
            }
        }
    }
}
