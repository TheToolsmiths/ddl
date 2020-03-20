using System;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Parser.Lexers;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    internal class EnumDefinitionDisambiguatorParser : IRootParser<RootParserContext>
    {
        public const string EnumStructKeyword = "struct";

        public EnumDefinitionDisambiguatorParser()
        {
            this.EnumStructParser = new EnumStructDefinitionParser();

            this.EnumParser = new EnumDefinitionParser();
        }

        public EnumDefinitionParser EnumParser { get; }

        public EnumStructDefinitionParser EnumStructParser { get; }

        public async ValueTask<ParseResult<IRootContentItem>> ParseRootContent(RootParserContext context)
        {
            var result = await context.Lexer.TryGetIdentifierToken();

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var token = result.Token;

            if (token.Memory.Span.SequenceEqual(EnumStructKeyword))
            {
                return await this.EnumStructParser.ParseRootContent(context);
            }

            var enumContext = EnumParserContext.WithIdentifier(context, token);
            return await this.EnumParser.ParseRootContent(enumContext);
        }
    }
}
