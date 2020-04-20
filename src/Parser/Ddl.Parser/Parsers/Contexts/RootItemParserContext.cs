using System.Collections.Generic;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Shared;
using TheToolsmiths.Ddl.Parser.Shared.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers.Contexts
{
    public class RootItemParserContext : IRootItemParserContext
    {
        public RootItemParserContext(IParserContext parserContext, IReadOnlyList<IAttributeUse> attributeList)
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
