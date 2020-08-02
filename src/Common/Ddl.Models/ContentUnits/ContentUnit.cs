using TheToolsmiths.Ddl.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Models.ContentUnits
{
    public class ContentUnit
    {
        public ContentUnit(
            ContentUnitId id,
            ContentUnitInfo info,
            IRootScope rootScope)
        {
            this.Id = id;
            this.Info = info;
            this.RootScope = rootScope;
        }

        public ContentUnit(
            ContentUnitInfo info,
            IRootScope rootScope)
        {
            this.Id = ContentUnitId.CreateNew();
            this.Info = info;
            this.RootScope = rootScope;
        }

        public ContentUnitId Id { get; }

        public ContentUnitInfo Info { get; }

        public IRootScope RootScope { get; }
    }
}
