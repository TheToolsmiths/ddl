using Ddl.Common;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase.ContentItems.Resolvers
{
    public interface IRootContentItemResolver<in T>
        where T : IRootItem
    {
        public Result CatalogItem(ContentUnitScopeResolveContext unitContext, T item);
    }
}
