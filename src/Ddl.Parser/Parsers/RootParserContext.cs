using TheToolsmiths.Ddl.Parser.Lexers;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public class RootParserContext : IParserContext
    {
        public RootParserContext(DdlLexer lexer, ContextParsers parsers)
        {
            this.Lexer = lexer;
            this.Parsers = parsers;
        }

        public DdlLexer Lexer { get; }

        public ContextParsers Parsers { get; }
    }
}
