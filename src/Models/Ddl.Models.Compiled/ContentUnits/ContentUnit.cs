namespace TheToolsmiths.Ddl.Models.Compiled.ContentUnits
{
    public class ContentUnit
    {
        public ContentUnit(
            ContentUnitId id,
            ContentUnitInfo info,
            ContentUnitScope rootScope)
        {
            this.Id = id;
            this.Info = info;
            this.RootScope = rootScope;
        }

        public ContentUnit(
            ContentUnitInfo info,
            ContentUnitScope rootScope)
        {
            this.Id = ContentUnitId.CreateNew();
            this.Info = info;
            this.RootScope = rootScope;
        }

        public ContentUnitId Id { get; }

        public ContentUnitInfo Info { get; }

        public ContentUnitScope RootScope { get; }
    }
}
