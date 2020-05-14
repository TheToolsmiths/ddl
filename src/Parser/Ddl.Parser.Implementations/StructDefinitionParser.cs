using System;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Models.Structs;
using TheToolsmiths.Ddl.Parser.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Implementations
{
    internal class StructDefinitionParser : IRootItemParser
    {
        public async ValueTask<RootParseResult<IRootItem>> ParseRootContent(IRootItemParserContext context)
        {
            ITypeName typeName;
            {
                var result = await context.Parsers.ParseTypeName().ConfigureAwait(false);

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
                var parseResult = await context.Parsers.ParseStructDefinitionContentParser().ConfigureAwait(false);

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

            return RootParseResult.FromResult<IRootItem>(value);
        }
    }
}
