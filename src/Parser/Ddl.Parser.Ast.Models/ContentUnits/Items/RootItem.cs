namespace TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items
{
    public abstract class RootItem : IRootItem
    {
        public abstract ContentUnitItemType ItemType { get; }
    }
}
