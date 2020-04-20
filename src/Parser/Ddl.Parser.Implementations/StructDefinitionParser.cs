using System;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Models.FileContents;
using TheToolsmiths.Ddl.Parser.Models.Structs;
using TheToolsmiths.Ddl.Parser.Models.Types;
using TheToolsmiths.Ddl.Parser.Shared;
using TheToolsmiths.Ddl.Parser.Shared.Contexts;

namespace TheToolsmiths.Ddl.Parser.Implementations
{
    internal class StructDefinitionParser : IRootItemParser
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

            StructDefinitionContent content;
            {
                var parseResult = await context.Parsers.ParseStructDefinitionContentParser();

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

            var value = new StructDefinition(typeName, content, context.AttributeList);

            return RootParseResult<IRootContentItem>.FromResult(value);
        }
    }
}
