namespace TheToolsmiths.Ddl.Parser.Models.FileContents
{
    public abstract class RootContentItem : IRootContentItem
    {
        public abstract FileContentItemType ItemType { get; }
    }
}
