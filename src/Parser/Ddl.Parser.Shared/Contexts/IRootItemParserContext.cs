using System.Collections.Generic;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;

namespace TheToolsmiths.Ddl.Parser.Contexts
{
    public interface IRootItemParserContext
    {
        IReadOnlyList<IAttributeUse> AttributeList { get; }

        ILexer Lexer { get; }

        ICommonParsers Parsers { get; }

        IParserContext ParserContext { get; }
    }
}
