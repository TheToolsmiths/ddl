namespace TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items
{
    public abstract class RootContentItem : IRootContentItem
    {
        public abstract ContentUnitItemType ItemType { get; }
    }
}
