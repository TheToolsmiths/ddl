using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Shared.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public interface IRootItemParserContextFactory
    {
        IRootItemParserContext CreateContext(IParserContext parserContext, IReadOnlyList<IAttributeUse> attributeList);
    }
}
