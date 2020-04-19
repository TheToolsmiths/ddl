using TheToolsmiths.Ddl.Lexer;

namespace TheToolsmiths.Ddl.Parser.Shared.Contexts
{
    public interface IParserContext
    {
        ILexer Lexer { get; }

        ICommonParsers Parsers { get; }
    }
}
