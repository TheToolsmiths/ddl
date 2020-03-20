using System;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Parser.Lexers;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    internal class EnumDefinitionParser : IRootParser<EnumParserContext>
    {
        public ValueTask<ParseResult<IRootContentItem>> ParseRootContent(EnumParserContext context)
        {
            throw new NotImplementedException();
        }
    }

    internal class EnumParserContext : RootParserContext
    {
        private EnumParserContext(DdlLexer lexer, ContextParsers parsers, LexerToken identifier)
            : base(lexer, parsers)
        {
        }

        public static EnumParserContext WithIdentifier(RootParserContext context, LexerToken identifier)
        {
            return new EnumParserContext(context.Lexer, context.Parsers, identifier);
        }
    }
}
