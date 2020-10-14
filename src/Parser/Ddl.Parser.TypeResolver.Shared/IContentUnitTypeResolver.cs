using TheToolsmiths.Ddl.Models.Build.ContentUnits;
using TheToolsmiths.Ddl.Parser.TypeResolver.Contexts;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver
{
    public interface IContentUnitTypeResolver
    {
        Result<ContentUnitScope> ResolveContentUnitScopeTypes(IRootScopeTypeResolveContext context, ContentUnitScope rootScope);
    }
}
