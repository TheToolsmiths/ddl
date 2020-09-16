using TheToolsmiths.Ddl.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.TypeResolver.Contexts;
using TheToolsmiths.Ddl.Parser.TypeResolver.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver
{
    public interface IRootScopeTypeResolver
    {
        RootScopeTypeResolveResult ResolveScopeTypes(IRootScopeTypeResolveContext context, IRootScope scope);
    }
}
