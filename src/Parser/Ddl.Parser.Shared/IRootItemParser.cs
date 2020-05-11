using System.Threading.Tasks;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items;

namespace TheToolsmiths.Ddl.Parser
{
    public interface IRootItemParser
    {
        ValueTask<RootParseResult<IRootContentItem>> ParseRootContent(IRootItemParserContext context);
    }
}
