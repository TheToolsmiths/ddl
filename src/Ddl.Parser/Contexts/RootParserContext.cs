using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Containers;
using TheToolsmiths.Ddl.Parser.Parsers;

namespace TheToolsmiths.Ddl.Parser.Contexts
{
    public class RootParserContext : IRootParserContext
    {
        private readonly CharSpanKeyedMap<IRootParser> mainParsersMap;

        public RootParserContext(
            DdlLexer lexer,
            ContextParsers parsers,
            CharSpanKeyedMap<IRootParser> mainParsersMap)
        {
            this.Lexer = lexer;
            this.Parsers = parsers;
            this.mainParsersMap = mainParsersMap;
        }

        public DdlLexer Lexer { get; }

        public ContextParsers Parsers { get; }


        public bool TryGetParserForRootKeyword(in ReadOnlySpan<char> key, out IRootParser parser)
        {
            return this.mainParsersMap.TryGetValue(key, out parser);
        }

        public IRootItemParserContext CreateItemParserContext(IReadOnlyList<IAttributeUse> attributeList)
        {
            return new RootItemParserContext(this, attributeList);
        }
    }
}
