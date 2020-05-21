using System.Collections.Generic;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers.Contexts
{
    public class RootScopeParserContext : IRootScopeParserContext
    {
        public RootScopeParserContext(IParserContext parserContext, IReadOnlyList<IAttributeUse> attributeList)
        {
            this.AttributeList = attributeList;
            this.ParserContext = parserContext;
        }

        public IReadOnlyList<IAttributeUse> AttributeList { get; }

        public ILexer Lexer => this.ParserContext.Lexer;

        public ICommonParsers Parsers => this.ParserContext.Parsers;

        public IParserContext ParserContext { get; }
    }
}
