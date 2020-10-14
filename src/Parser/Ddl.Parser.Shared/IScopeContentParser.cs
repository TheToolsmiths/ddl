using System.Threading.Tasks;
using TheToolsmiths.Ddl.Models.Ast.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser
{
    public interface IScopeContentParser
    {
        Task<Result<AstScopeContent>> ParseRootScopeContent(IParserContext context);
    }
}
