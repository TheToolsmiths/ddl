using TheToolsmiths.Ddl.Parser.Lexers;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public interface IParserContext
    {
        DdlLexer Lexer { get; }

        ContextParsers Parsers { get; }
    }
}
