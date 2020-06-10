namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items
{
    public abstract class AstRootItem : IAstRootItem
    {
        public abstract ContentUnitItemType ItemType { get; }
    }
}
