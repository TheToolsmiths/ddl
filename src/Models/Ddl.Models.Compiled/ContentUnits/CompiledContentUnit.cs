namespace TheToolsmiths.Ddl.Models.Compiled.ContentUnits
{
    public class CompiledContentUnit
    {
        public CompiledContentUnit(
            ContentUnitId id,
            ContentUnitInfo info,
            CompiledContentUnitScope rootScope)
        {
            this.Id = id;
            this.Info = info;
            this.RootScope = rootScope;
        }

        public CompiledContentUnit(
            ContentUnitInfo info,
            CompiledContentUnitScope rootScope)
        {
            this.Id = ContentUnitId.CreateNew();
            this.Info = info;
            this.RootScope = rootScope;
        }

        public ContentUnitId Id { get; }

        public ContentUnitInfo Info { get; }

        public CompiledContentUnitScope RootScope { get; }
    }
}
