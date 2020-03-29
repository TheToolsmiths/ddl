﻿using System;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Models.Structs;
using TheToolsmiths.Ddl.Models.Types;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers.Implementations
{
    internal class StructDefinitionParser : IRootParser<RootParserContext>
    {
        public async ValueTask<ParseResult<IRootContentItem>> ParseRootContent(RootParserContext context)
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

            StructDefinitionContent content;
            {
                var parseResult = await context.Parsers.ParseStructDefinitionContentParser(context);

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

            return new ParseResult<IRootContentItem>(value);
        }
    }
}
