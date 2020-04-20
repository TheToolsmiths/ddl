using System.Collections.Generic;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Parser.Models.FileContents;
using TheToolsmiths.Ddl.Parser.Shared.Contexts;

namespace TheToolsmiths.Ddl.Parser.Shared
{
    public interface IFileRootContentParser
    {
        Task<ParseResult<IReadOnlyList<IRootContentItem>>> ParseRootContentScope(IParserContext context);

        Task<RootParseResult<IRootContentItem>> ParseRootContent(IParserContext context);
    }
}
