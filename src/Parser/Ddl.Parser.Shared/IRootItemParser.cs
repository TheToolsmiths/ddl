using System.Threading.Tasks;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser
{
    public interface IRootItemParser
    {
        ValueTask<RootItemParseResult> ParseRootContent(IRootItemParserContext context);
    }
}
