namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items
{
    public abstract class RootItem : IRootItem
    {
        public abstract ContentUnitItemType ItemType { get; }
    }
}
