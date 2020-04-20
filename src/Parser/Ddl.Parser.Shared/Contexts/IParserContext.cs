using TheToolsmiths.Ddl.Lexer;

namespace TheToolsmiths.Ddl.Parser.Contexts
{
    public interface IParserContext
    {
        ILexer Lexer { get; }

        ICommonParsers Parsers { get; }
    }
}
