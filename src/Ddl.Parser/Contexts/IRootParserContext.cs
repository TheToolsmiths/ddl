using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Parsers;

namespace TheToolsmiths.Ddl.Parser.Contexts
{
    public interface IRootParserContext : IParserContext
    {
        bool TryGetParserForRootKeyword(in ReadOnlySpan<char> keyword, out IRootParser parser);

        IRootItemParserContext CreateItemParserContext(IReadOnlyList<IAttributeUse> attributeList);
    }
}
