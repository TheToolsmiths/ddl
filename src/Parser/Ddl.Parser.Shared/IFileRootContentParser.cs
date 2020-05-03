using System.Collections.Generic;
using System.Threading.Tasks;
using Ddl.Common;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;

namespace TheToolsmiths.Ddl.Parser
{
    public interface IFileRootContentParser
    {
        Task<Result<IReadOnlyList<IRootContentItem>>> ParseRootContentScope(IParserContext context);

        Task<RootParseResult<IRootContentItem>> ParseRootContent(IParserContext context);
    }
}
