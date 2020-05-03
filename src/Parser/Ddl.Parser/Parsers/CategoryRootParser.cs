using System;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public class CategoryRootParser : IRootItemParser
    {
        private readonly IRootParserResolver parserResolver;

        public CategoryRootParser(IRootParserResolver parserResolver)
        {
            this.parserResolver = parserResolver;
        }

        public async ValueTask<RootParseResult<IRootContentItem>> ParseRootContent(IRootItemParserContext context)
        {
            var result = await context.Lexer.TryGetIdentifierToken();

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var token = result.Token;

            if (this.parserResolver.TryResolveParser(token.Memory.Span, out var parser) == false)
            {
                string[] identifiers = { token.Memory.Span.ToString() };

                return RootParseResult<IRootContentItem>.CreateParserHandlerNotFound(identifiers);
            }

            return await parser.ParseRootContent(context);
        }
    }
}
