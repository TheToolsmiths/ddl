using System.Threading.Tasks;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Parser
{
    public interface IRootScopeParser
    {
        ValueTask<RootParseResult<IRootScope>> ParseRootScope(IRootScopeParserContext context);
    }
}
