using System;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Models.Ast.Structs;
using TheToolsmiths.Ddl.Models.Ast.Types.Names;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser.Implementations
{
    internal class StructDefinitionParser : IRootItemParser
    {
        public async ValueTask<RootItemParseResult> ParseRootContent(IRootItemParserContext context)
        {
            TypeName typeName;
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

            var value = new StructAstDefinition(typeName, content, context.AttributeList);

            return RootItemParseResult.FromResult(value);
        }
    }
}
