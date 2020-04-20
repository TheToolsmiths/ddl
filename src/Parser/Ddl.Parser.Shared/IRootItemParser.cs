using System.Threading.Tasks;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;

namespace TheToolsmiths.Ddl.Parser
{
    public interface IRootItemParser : IParser
    {
        ValueTask<RootParseResult<IRootContentItem>> ParseRootContent(IRootItemParserContext context);
    }
}
