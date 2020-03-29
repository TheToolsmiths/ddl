using System.Collections.Generic;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Parsers;

namespace TheToolsmiths.Ddl.Parser.Contexts
{
    public class RootParserContext : IParserContext
    {
        public RootParserContext(DdlLexer lexer, IReadOnlyList<IAttributeUse> attributeList, ContextParsers parsers)
        {
            this.Lexer = lexer;
            this.AttributeList = attributeList;
            this.Parsers = parsers;
        }

        public DdlLexer Lexer { get; }

        public IReadOnlyList<IAttributeUse> AttributeList { get; }

        public ContextParsers Parsers { get; }
    }
}
