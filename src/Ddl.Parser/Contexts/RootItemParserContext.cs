using System.Collections.Generic;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Parsers;

namespace TheToolsmiths.Ddl.Parser.Contexts
{
    public class RootItemParserContext : IRootItemParserContext
    {
        public RootItemParserContext(IRootParserContext rootContext, IReadOnlyList<IAttributeUse> attributeList)
        {
            this.RootParserContext = rootContext;
            this.Lexer = rootContext.Lexer;
            this.Parsers = rootContext.Parsers;
            this.AttributeList = attributeList;
        }

        public DdlLexer Lexer { get; }

        public ContextParsers Parsers { get; }

        public IReadOnlyList<IAttributeUse> AttributeList { get; }

        public IRootParserContext RootParserContext { get; }
    }
}
