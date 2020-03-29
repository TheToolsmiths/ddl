using System.Threading.Tasks;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers.Implementations
{
    internal class ImportParser : IRootParser<RootParserContext>
    {
        public ValueTask<ParseResult<IRootContentItem>> ParseRootContent(RootParserContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
