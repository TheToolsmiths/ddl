using System.Threading.Tasks;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public interface IRootParser
    {
        ValueTask<RootParseResult<IRootContentItem>> ParseRootContent(IRootItemParserContext context);
    }
}
