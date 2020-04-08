using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Models.Enums;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Models.Identifiers;
using TheToolsmiths.Ddl.Models.Structs;
using TheToolsmiths.Ddl.Models.Types;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers.Implementations
{
    internal class EnumDefinitionParser : IRootParser
    {
        public async ValueTask<ParseResult<IRootContentItem>> ParseRootContent(IRootItemParserContext context)
        {
            ITypeName typeName;
            {
                var result = await context.Parsers.ParseTypeName(context);

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

            return new ParseResult<IRootContentItem>(value);
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

                {
                    var result = await context.Lexer.TryGetIdentifierToken();

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    var token = result.Token;

                    var identifier = new Identifier(token.Memory.ToString());

                    var item = new EnumDefinitionConstantDefinition(identifier);

                    items.Add(item);
                }

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
        }
    }
}
