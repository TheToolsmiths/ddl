using System.Threading.Tasks;
using TheToolsmiths.Ddl.Parser.Models.FileContents;
using TheToolsmiths.Ddl.Parser.Shared.Contexts;

namespace TheToolsmiths.Ddl.Parser.Shared
{
    public interface IRootItemParser : IParser
    {
        ValueTask<RootParseResult<IRootContentItem>> ParseRootContent(IRootItemParserContext context);
    }
}
