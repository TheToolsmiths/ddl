using TheToolsmiths.Ddl.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Models.ContentUnits
{
    public class ContentUnit
    {
        public ContentUnit(
            ContentUnitId id,
            IRootScope rootScope)
        {
            this.Id = id;
            this.RootScope = rootScope;
        }
        public ContentUnit(IRootScope rootScope)
        {
            this.Id = ContentUnitId.CreateNew();
            this.RootScope = rootScope;
        }

        public ContentUnitId Id { get; }

        public IRootScope RootScope { get; }
    }
}
