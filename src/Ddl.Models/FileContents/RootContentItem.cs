namespace TheToolsmiths.Ddl.Models.FileContents
{
    public abstract class RootContentItem : IRootContentItem
    {
        public abstract FileContentItemType ItemType { get; }
    }
}
