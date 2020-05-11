using System.Threading.Tasks;
using Ddl.Common;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Parser
{
    public interface IRootScopeContentParser
    {
        Task<Result<RootScopeContent>> ParseRootScopeContent(IParserContext context);
    }
}
