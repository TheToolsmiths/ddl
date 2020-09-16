using System;
using System.Threading.Tasks;

using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public class CategoryRootItemParser : IRootItemParser
    {
        private readonly IRootParserResolver parserResolver;

        public CategoryRootItemParser(IRootParserResolver parserResolver)
        {
            this.parserResolver = parserResolver;
        }

        public async ValueTask<RootItemParseResult> ParseRootContent(IRootItemParserContext context)
        {
            var result = await context.Lexer.TryPeekIdentifierToken();

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var token = result.Token;

            if (this.parserResolver.TryResolveItemParser(token.Memory.Span, out var itemParser))
            {
                context.Lexer.PopToken();

                return await itemParser.ParseRootContent(context);
            }

            if (this.parserResolver.TryResolveDefaultItemParser(out var defaultItemParser))
            {
                return await defaultItemParser.ParseRootContent(context);
            }

            string[] identifiers = { token.Memory.Span.ToString() };

            return RootItemParseResult.CreateParserHandlerNotFound(identifiers);

        }
    }
}
