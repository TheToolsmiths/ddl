using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public interface IRootItemParserContextFactory
    {
        IRootItemParserContext CreateContext(IParserContext parserContext, AstAttributeUseCollection attributeList);
    }
}
