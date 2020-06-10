using System.Threading.Tasks;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser
{
    public interface IRootScopeParser
    {
        ValueTask<RootParseResult<IAstRootScope>> ParseRootScope(IRootScopeParserContext context);
    }
}
