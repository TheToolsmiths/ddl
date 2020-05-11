using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public interface IRootScopeParserContextFactory
    {
        IRootScopeParserContext CreateContext(IParserContext parserContext, IReadOnlyList<IAttributeUse> attributeList);
    }
}
