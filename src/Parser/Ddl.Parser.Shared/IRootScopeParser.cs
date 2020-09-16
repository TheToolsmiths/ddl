using System.Threading.Tasks;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser
{
    public interface IRootScopeParser
    {
        ValueTask<RootScopeParseResult> ParseRootScope(IRootScopeParserContext context);
    }
}
