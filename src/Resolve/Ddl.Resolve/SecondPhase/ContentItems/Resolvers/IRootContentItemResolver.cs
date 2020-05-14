using Ddl.Common;

namespace TheToolsmiths.Ddl.Resolve.SecondPhase.ContentItems.Resolvers
{
    public interface IRootContentItemResolver<in T>
    {
        public Result CatalogItem(
            ScopeItemResolveContext unitContext,
            T importStatement);
    }
}
