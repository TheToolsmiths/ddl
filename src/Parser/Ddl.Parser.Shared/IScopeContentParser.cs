using System.Threading.Tasks;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser
{
    public interface IScopeContentParser
    {
        Task<Result<AstScopeContent>> ParseRootScopeContent(IParserContext context);
    }
}
