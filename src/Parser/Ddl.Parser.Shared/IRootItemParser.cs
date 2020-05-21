using System.Threading.Tasks;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser
{
    public interface IRootItemParser
    {
        ValueTask<RootParseResult<IRootItem>> ParseRootContent(IRootItemParserContext context);
    }
}
