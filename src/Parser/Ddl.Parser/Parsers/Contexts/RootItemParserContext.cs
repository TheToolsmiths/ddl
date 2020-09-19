using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers.Contexts
{
    public class RootItemParserContext : IRootItemParserContext
    {
        public RootItemParserContext(IParserContext parserContext, AstAttributeUseCollection attributeList)
        {
            this.AttributeList = attributeList;
            this.ParserContext = parserContext;
        }

        public AstAttributeUseCollection AttributeList { get; }

        public ILexer Lexer => this.ParserContext.Lexer;

        public ICommonParsers Parsers => this.ParserContext.Parsers;

        public IParserContext ParserContext { get; }
    }
}
