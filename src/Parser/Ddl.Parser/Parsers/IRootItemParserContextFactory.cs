using TheToolsmiths.Ddl.Models.Ast.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public interface IRootItemParserContextFactory
    {
        IRootItemParserContext CreateContext(IParserContext parserContext, AstAttributeUseCollection attributeList);
    }
}
