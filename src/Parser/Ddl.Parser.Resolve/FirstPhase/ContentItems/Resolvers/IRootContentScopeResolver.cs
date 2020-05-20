using Ddl.Common;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase.ContentItems.Resolvers
{
    public interface IRootContentScopeResolver<in T>
        where T : IRootScope
    {
        public Result CatalogScope(ContentUnitScopeResolveContext unitContext, T scope);
    }
}
