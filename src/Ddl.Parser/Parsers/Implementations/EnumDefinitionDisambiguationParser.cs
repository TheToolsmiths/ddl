using System;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers.Implementations
{
    internal class EnumDefinitionDisambiguationParser : IRootParser
    {
        public EnumDefinitionDisambiguationParser()
        {
            this.EnumStructParser = new EnumStructDefinitionParser();

            this.EnumParser = new EnumDefinitionParser();
        }

        public EnumDefinitionParser EnumParser { get; }

        public EnumStructDefinitionParser EnumStructParser { get; }

        public async ValueTask<ParseResult<IRootContentItem>> ParseRootContent(IRootItemParserContext context)
        {
            var result = await context.Lexer.TryPeekIdentifierToken();

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var token = result.Token;

            if (token.Memory.Span.SequenceEqual(ParserIdentifierConstants.Struct))
            {
                context.Lexer.PopToken();

                return await this.EnumStructParser.ParseRootContent(context);
            }

            return await this.EnumParser.ParseRootContent(context);
        }
    }
}
