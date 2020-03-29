using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Parsers;

namespace TheToolsmiths.Ddl.Parser.Contexts
{
    public interface IParserContext
    {
        DdlLexer Lexer { get; }

        ContextParsers Parsers { get; }
    }
}
