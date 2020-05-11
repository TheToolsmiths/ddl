using Ddl.Common;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase.ContentItems.Resolvers
{
    public interface IRootContentScopeResolver<T>
        where T : IRootScope
    {
        public Result CatalogScope(ContentUnitScopeResolveContext unitContext, T importStatement);
    }
}
