using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Parser.Parsers.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public class RootItemParserContextFactory : IRootItemParserContextFactory
    {
        public IRootItemParserContext CreateContext(IParserContext parserContext, IReadOnlyList<IAstAttributeUse> attributeList)
        {
            return new RootItemParserContext(parserContext, attributeList);
        }
    }
}
