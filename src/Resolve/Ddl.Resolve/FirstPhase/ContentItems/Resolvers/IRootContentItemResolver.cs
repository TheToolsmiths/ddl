using Ddl.Common;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase.ContentItems.Resolvers
{
    public interface IRootContentItemResolver<T>
        where T : IRootContentItem
    {
        public Result CatalogItem(ContentUnitScopeResolveContext unitContext, T item);
    }
}
