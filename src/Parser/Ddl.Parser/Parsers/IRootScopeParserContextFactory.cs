using TheToolsmiths.Ddl.Models.Ast.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public interface IRootScopeParserContextFactory
    {
        IRootScopeParserContext CreateContext(IParserContext parserContext, AstAttributeUseCollection attributeList);
    }
}
