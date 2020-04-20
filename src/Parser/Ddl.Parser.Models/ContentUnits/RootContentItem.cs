namespace TheToolsmiths.Ddl.Parser.Models.ContentUnits
{
    public abstract class RootContentItem : IRootContentItem
    {
        public abstract ContentUnitItemType ItemType { get; }
    }
}
