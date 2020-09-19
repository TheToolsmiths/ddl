using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Parser.Parsers.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public class RootScopeParserContextFactory : IRootScopeParserContextFactory
    {
        public IRootScopeParserContext CreateContext(IParserContext parserContext, AstAttributeUseCollection attributeList)
        {
            return new RootScopeParserContext(parserContext, attributeList);
        }
    }
}
