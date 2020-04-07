using System.Threading.Tasks;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public interface IRootParser
    {
        ValueTask<ParseResult<IRootContentItem>> ParseRootContent(IRootItemParserContext context);
    }
}
