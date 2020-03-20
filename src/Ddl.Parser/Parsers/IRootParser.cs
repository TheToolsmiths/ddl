using System.Threading.Tasks;
using TheToolsmiths.Ddl.Models.FileContents;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public interface IRootParser<in TContext>
        where TContext : RootParserContext
    {
        ValueTask<ParseResult<IRootContentItem>> ParseRootContent(TContext context);
    }
}
