using System.Threading.Tasks;
using TheToolsmiths.Ddl.Models.FileContents;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    internal class StructDefinitionParser : IRootParser<RootParserContext>
    {
        public ValueTask<ParseResult<IRootContentItem>> ParseRootContent(RootParserContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
