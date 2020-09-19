using System.Collections.Generic;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;

namespace TheToolsmiths.Ddl.Parser.Contexts
{
    public interface IRootScopeParserContext
    {
        AstAttributeUseCollection AttributeList { get; }

        ILexer Lexer { get; }

        ICommonParsers Parsers { get; }

        IParserContext ParserContext { get; }
    }
}
