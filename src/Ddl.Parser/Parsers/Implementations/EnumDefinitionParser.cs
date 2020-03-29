using System;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Models.FileContents;

namespace TheToolsmiths.Ddl.Parser.Parsers.Implementations
{
    internal class EnumDefinitionParser : IRootParser<EnumParserContext>
    {
        public ValueTask<ParseResult<IRootContentItem>> ParseRootContent(EnumParserContext context)
        {
            throw new NotImplementedException();
        }
    }
}
