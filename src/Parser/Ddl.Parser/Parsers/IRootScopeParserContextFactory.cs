using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public interface IRootScopeParserContextFactory
    {
        IRootScopeParserContext CreateContext(IParserContext parserContext, IReadOnlyList<IAstAttributeUse> attributeList);
    }
}
