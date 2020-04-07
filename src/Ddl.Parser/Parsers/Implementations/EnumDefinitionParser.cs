using System;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers.Implementations
{
    internal class EnumDefinitionParser : IRootParser
    {
        public ValueTask<ParseResult<IRootContentItem>> ParseRootContent(IRootItemParserContext context)
        {
            throw new NotImplementedException();
        }
    }
}
