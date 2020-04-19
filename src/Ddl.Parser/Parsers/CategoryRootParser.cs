using System;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Parser.Shared;
using TheToolsmiths.Ddl.Parser.Shared.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public class CategoryRootParser : IRootItemParser
    {
        private readonly IParserMapRegistry registry;

        public CategoryRootParser(IParserMapRegistry registry)
        {
            this.registry = registry;
        }

        public async ValueTask<RootParseResult<IRootContentItem>> ParseRootContent(IRootItemParserContext context)
        {
            var result = await context.Lexer.TryGetIdentifierToken();

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var token = result.Token;

            if (this.registry.TryGetParser(token.Memory.Span, out var parser) == false)
            {
                string[] identifiers = { token.Memory.Span.ToString() };

                return RootParseResult<IRootContentItem>.CreateParserHandlerNotFound(identifiers);
            }

            return await parser.ParseRootContent(context);
        }
    }
}
