using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Parsers;

namespace TheToolsmiths.Ddl.Parser.Contexts
{
    public class AttributeParserContext : IParserContext
    {
        public AttributeParserContext(DdlLexer lexer, ContextParsers parsers)
        {
            this.Lexer = lexer;
            this.Parsers = parsers;
        }

        public DdlLexer Lexer { get; }

        public ContextParsers Parsers { get; }
    }
}
