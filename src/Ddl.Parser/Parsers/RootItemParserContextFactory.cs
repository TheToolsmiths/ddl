using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Parsers.Contexts;
using TheToolsmiths.Ddl.Parser.Shared.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public class RootItemParserContextFactory : IRootItemParserContextFactory
    {
        public IRootItemParserContext CreateContext(IParserContext parserContext, IReadOnlyList<IAttributeUse> attributeList)
        {
            return new RootItemParserContext(parserContext, attributeList);
        }
    }
}
