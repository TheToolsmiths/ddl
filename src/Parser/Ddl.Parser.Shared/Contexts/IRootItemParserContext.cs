using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Models.Ast.AttributeUsage;

namespace TheToolsmiths.Ddl.Parser.Contexts
{
    public interface IRootItemParserContext
    {
        AstAttributeUseCollection AttributeList { get; }

        ILexer Lexer { get; }

        ICommonParsers Parsers { get; }

        IParserContext ParserContext { get; }
    }
}
